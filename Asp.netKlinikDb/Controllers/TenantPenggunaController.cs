using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantPenggunaController : ControllerBase
    {
        private ITenantPengguna _TenantPengguna;

        public TenantPenggunaController(ITenantPengguna tenantPengguna)
        {
            _TenantPengguna = tenantPengguna;
        }
        // GET: api/TenantPengguna
        [HttpGet]
        public async Task<IEnumerable<TenantPengguna>> getall()
        {

            var Models = await _TenantPengguna.GetAll();
            return Models;
        }
        // POST: api/Pengguna
        [HttpPost]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]

        public async Task<IActionResult> Post([FromBody] TenantPengguna tenantPengguna)
        {
            try
            {
                    await _TenantPengguna.CreateAsync(tenantPengguna);
                    return Ok("Tambah Data Berhasil");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/TenatnPengguna/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Put([FromBody] TenantPengguna tenantPengguna)
        {
            try
            {
                await _TenantPengguna.UpdateAsync(tenantPengguna);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/KatBarang/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _TenantPengguna.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/TenantPengguna/5
        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<TenantPengguna> Get(string id)
        {

            var model = await _TenantPengguna.GetbyTenantPenggunaID(id);
            return model;
        }
        [HttpGet("gettenantbyusername/{Username}")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        // POST: api/getbarangbytenantid/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // CEK apakah id kat barang sudah sesuai dengan Tenant s
        public async Task<IActionResult> gettenantbyusername(string Username)
        {

            var model = await _TenantPengguna.getusertenantlist(Username);
            return Ok(model);

        }

    }
}