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
    public class JenisTindakanController : ControllerBase
    {
        private IJenisTindakan _JenisTindakan;

        public JenisTindakanController(IJenisTindakan _jenisTindakan)
        {
            _JenisTindakan = _jenisTindakan;
        }

        // GET: api/jenistindakan
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<JenisTindakan>> GetKatJenis()
        {

            var Models = await _JenisTindakan.GetAll();
            return Models;
        }

        // GET: api/JenisTindakan/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<JenisTindakan> Get(int id)
        {

            var model = await _JenisTindakan.GetById(id);
            return model;
        }
        [HttpGet("getkatjenistindakanbytenantid")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        // POST: api/getbarangbytenantid/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // CEK apakah id kat barang sudah sesuai dengan Tenant s
        public async Task<IActionResult> getkatjenisbytenantid(string TenantID)
        {

            var model = await _JenisTindakan.getbytenantid(TenantID);
            return Ok(model);

        }
        //[HttpGet("{TenantID,NamaKategori}")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        //[Route("sortbyidandtenant")]
        //// POST: api/sortbyidandtenant/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        //// case jikalau ingin sort dengan menggunakan tenant dan nama kategori 
        //public async Task<IActionResult> sortbyidandtenant(string TenantID, string NamaKategori)
        //{
        //    //test data yang di gunakan 
        //    //TenantID = "ccc";
        //    //NamaKategori = "obat2";
        //    var model = await _KatBarang.sortbytenantandidkategori(TenantID, NamaKategori);
        //    return Ok(model);

        //}
        // PUT: api/KatBarang/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Put([FromBody] JenisTindakan jenisTindakan)
        {
            try
            {
                await _JenisTindakan.UpdateAsync(jenisTindakan);
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
        public async Task<IActionResult> Post([FromBody] JenisTindakan JenisTindakan)
        {
            try
            {

                await _JenisTindakan.CreateAsync(JenisTindakan);
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
                await _JenisTindakan.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}