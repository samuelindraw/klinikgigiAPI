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
    public class KatJenisController : ControllerBase
    {
        private IKatJenis _KatJenis;

        public KatJenisController(IKatJenis katJenis)
        {
            _KatJenis = katJenis;
        }

        // GET: api/KatBarang
        [HttpGet]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IEnumerable<KatJenis>> GetKatJenis()
        {

            var Models = await _KatJenis.GetAll();
            return Models;
        }

        // GET: api/KatJenis/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<KatJenis> Get(int id)
        {

            var model = await _KatJenis.GetById(id);
            return model;
        }
        [HttpGet("getkatjenisbytenantid")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        // POST: api/getbarangbytenantid/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // CEK apakah id kat barang sudah sesuai dengan Tenant s
        public async Task<IActionResult> getkatjenisbytenantid(string TenantID)
        {

            var model = await _KatJenis.getbytenantid(TenantID);
            return Ok(model);

        }

        // PUT: api/KatBarang/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Put([FromBody] KatJenis KatJenis)
        {
            try
            {
                await _KatJenis.UpdateAsync(KatJenis);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/KatBarang
        [HttpPost]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        //TIDAK BISA CREATE JIKA DATA KATBARANG DI TENANT YANG SAMA 
        public async Task<IActionResult> Post([FromBody] KatJenis KatJenis)
        {
            try
            {

                await _KatJenis.CreateAsync(KatJenis);
                return Ok("Tambah Data Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/KatBarang/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _KatJenis.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}