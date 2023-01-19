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
using Microsoft.Data.SqlClient;
using MLG.Models.StoredProcedures;

namespace MLG.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AppDbContextForSP _contextSP;
        private readonly IUserRepository _userService;

        public AccountController(AppDbContext context, AppDbContextForSP contextSP, IUserRepository userService)
        {
            _context = context;
            _contextSP = contextSP;
            _userService = userService;
        }

        [HttpGet("GetCustomersByAvailable/{available}")]
        public async Task<ActionResult<CustomerDropDownModel>> GetCustomersByAvailable(bool available)
        {
            try
            {
                var customers = await _context.Customers.Where(x => x.IsAvailable == available).Select(c => new CustomerDropDownModel
                {
                    PKCustomer = c.PKCustomer,
                    Name = c.Name + ' ' + c.LastName
                }).ToListAsync();

                return Ok(customers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<CustomerViewModel>> GetAllCustomers()
        {
            try
            {
                var customers = await _contextSP.up_GetAllCustomers.FromSqlRaw<up_GetAllCustomers_Result>("up_GetAllCustomers").ToListAsync();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CustomerViewModel customer)
        {
            try
            {
                if (await _userService.UserExist(customer.User)) return BadRequest("The username has already been registered.");

                List<SqlParameter> parms = _userService.GetParemeterForCustomer(customer, false);

                var results = await _context.Database.ExecuteSqlRawAsync("up_AddCustomer @Name, @LastName, @Address, @User, @Password, @LastUpdated, @IsAvailable", parms.ToArray());

                if (results == 1)
                {
                    return Ok("ResponseMessages.SuccessfulCreation");
                }
                else
                {
                    return BadRequest("ResponseMessages.IDNotFound");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerViewModel customer)
        {
            try
            {
                List<SqlParameter> parms = _userService.GetParemeterForCustomer(customer, true);

                var results = await _context.Database.ExecuteSqlRawAsync("up_ChgCustomerById @PKCustomer, @Name, @LastName, @Address, @LastUpdated, @Available", parms.ToArray());

                if (results == 1)
                {
                    return Ok("ResponseMessages.SuccessfulUpdate");
                }
                else
                {
                    return BadRequest("ResponseMessages.IDNotFound");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            try
            {
                // Validate if the user exist
                if (await _userService.UserExist(login.User))
                    return Unauthorized("Invalid username");

                List<SqlParameter> parms = new List<SqlParameter>();
                parms.Add(new SqlParameter { ParameterName = "User", Value = login.User.ToLower() });
                parms.Add(new SqlParameter { ParameterName = "Password", Value = login.Password });

                var user = await _contextSP.up_Login.FromSqlRaw<up_Login_Result>("up_Login @User, @Password", parms.ToArray()).AsNoTracking().ToListAsync();

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpPost("CreateUserArticle")]
        public async Task<IActionResult> CreateUserArticle(CustomerArticle userArticleData)
        {
            try
            {
                var userArticle = new CustomerArticle
                {
                    FKCustomer = userArticleData.FKCustomer,
                    FKArticle = userArticleData.FKArticle,
                    Date = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    IsAvailable = userArticleData.IsAvailable
                };

                //_context.CustomerArticles.Add(userArticle);
                await _context.SaveChangesAsync();

                return Ok("ResponseMessages.SuccessfulCreation");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpPut("UpdateUserArticle")]
        public async Task<IActionResult> UpdateCustomerArticle(CustomerArticle userArticleData)
        {
            try
            {
                CustomerArticle customerArticle = _userService.GetCustomerArticleByPK(userArticleData.PKCustomerArticle);
                customerArticle.FKCustomer = userArticleData.FKCustomer;
                customerArticle.FKArticle = userArticleData.FKArticle;
                customerArticle.LastUpdated = DateTime.Now;
                customerArticle.IsAvailable = userArticleData.IsAvailable;

                await _context.SaveChangesAsync();

                return Ok("ResponseMessages.SuccessfulUpdate");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }

        }

    }
}