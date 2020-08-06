using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private ITenant _tenant;
        public TenantController(ITenant TenantService)
        {

            _tenant = TenantService;
        }
        // GET: api/Tenant
        [HttpGet]
        //[Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<Tenant>> GetTenant()
        {


            var Models = await _tenant.GetAll();

            return Models;
        }
        // GET: api/Tenant/5
        [HttpGet("{id}")]
        //[Authorize(Roles  = "Admin")]
        public async Task<Tenant> Get(string Id)
        {
            var model = await _tenant.GetbytenantID(Id);
            return model;
        }
        // PUT: api/Tenant/5
        [HttpPut]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Put([FromBody] Tenant tenant)
        {
            try
            {
                await _tenant.UpdateAsync(tenant);
                return Ok("Data Tenant berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST: api/Tenant
        [HttpPost]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Post([FromBody] Tenant tenant)
        {
            try
            {
                await _tenant.CreateAsync(tenant);
                return Ok("Tambah Data Tenant Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/KatBarang/5
        [HttpDelete("{id}")]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _tenant.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}