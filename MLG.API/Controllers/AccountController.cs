using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLG.DataAccess;
using MLG.API.ViewModels;
using MLG.Models.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Text;
using MLG.API.Interfaces;

namespace MLG.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel customer)
        {
            if (await UserExist(customer.User)) return BadRequest("The username has already been registered.");

            return Ok(new UserViewModel
            {
                username = user.Username,
                Token = _tokenService.CreateToken(user)
            }); 
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel login) {

            // Validate if the user exist
            var user = await _context.Customers
                .SingleOrDefaultAsync(x => x.User == login.username.ToLower());

            if (user == null) return Unauthorized("Invalid username");

            // Validate the passowrd
            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));

            for (int i = 0; i < computedHash.Length; i++) {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return Ok(new UserDTO
            {
                username = user.Username,
                Token = _tokenService.CreateToken(user)
            });
        }

        private async Task<bool> UserExist(string username) 
        {
            return await _context.Users.AnyAsync(c => c.Username == username.ToLower());
        }

    }
}