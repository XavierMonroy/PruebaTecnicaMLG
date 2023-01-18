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
    public class StoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AppDbContextForSP _contextSP;
        private readonly IStoreRepository _storeService;

        public StoresController(AppDbContext context, AppDbContextForSP contextSP, IStoreRepository storeService)
        {
            _context = context;
            _contextSP = contextSP;
            _storeService = storeService;
        }

        [HttpGet("GetStoresByAvailable/{available}")]
        public async Task<ActionResult<StoresDropDownModel>> GetStoresByAvailable(bool available)
        {
            try
            {
                var stores = await _context.Stores.Where(x => x.IsAvailable == available).Select(c => new StoresDropDownModel
                {
                    PKStore = c.PKStore,
                    Subsidiary = c.Subsidiary
                }).ToListAsync();

                return Ok(stores);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpGet("GetAllStores")]
        public async Task<ActionResult<StoreViewModel>> GetAllStores()
        {
            try
            {
                var stores = await _context.Stores.Select(c => new StoreViewModel
                {
                    PKStore = c.PKStore,
                    Subsidiary = c.Subsidiary,
                    Address = c.Address,
                    LastUpdated = c.LastUpdated,
                    IsAvailable = (bool)c.IsAvailable
                }).ToListAsync();

                return Ok(stores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("createStore")]
        public async Task<IActionResult> CreateStore(Store storeData)
        {
            try
            {
                var store = new Store
                {
                    Subsidiary = storeData.Subsidiary,
                    Address = storeData.Address,
                    LastUpdated = DateTime.Now,
                    IsAvailable = storeData.IsAvailable
                };

                _context.Stores.Add(store);
                await _context.SaveChangesAsync();

                return Ok("ResponseMessages.SuccessfulCreation");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpPut("updateStore")]
        public async Task<IActionResult> UpdateStore(Store storeData)
        {
            try
            {
                Store store = _storeService.GetStoreByPK(storeData.PKStore);
                store.Subsidiary = storeData.Subsidiary;
                store.Address = storeData.Address;
                store.LastUpdated = DateTime.Now;
                store.IsAvailable = storeData.IsAvailable;

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