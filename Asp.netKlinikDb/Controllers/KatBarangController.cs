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
    public class KatBarangController : ControllerBase
    {
        private IKatBarang _KatBarang;

        public KatBarangController(IKatBarang katBarang)
        {
            _KatBarang = katBarang;
        }

        // GET: api/KatBarang
        [HttpGet]
        [Authorize(Roles = "Admin,Perawat,Dokter")]
        public async Task<IEnumerable<KatBarang>>GetBarang()
        {

            var Models = await _KatBarang.GetAll();
            return Models;
        }
       
        // GET: api/KatBarang/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<KatBarang>Get(int id)
        {
            
            var model = await _KatBarang.GetById(id);
            return model;
        }
        [HttpGet("getkatbarangbytenantid")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        // POST: api/getbarangbytenantid/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // CEK apakah id kat barang sudah sesuai dengan Tenant s
        public async Task<IActionResult> getbarangtenantid(string TenantID)
        {
            
            var model = await _KatBarang.getbytenantid(TenantID);
            return Ok(model);

        }
        [HttpGet("getkatbarangtenantid/{TenantID}")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        // POST: api/sortbyidandtenant/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // case jikalau ingin sort dengan menggunakan tenant dan nama kategori 
        public async Task<IActionResult> sortbyidandtenant(string TenantID)
        {
            //test data yang di gunakan 
            //TenantID = "ccc";
            //NamaKategori = "obat2";
            var model = await _KatBarang.getbytenantid(TenantID);
            return Ok(model);

        }
        // PUT: api/KatBarang/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Put([FromBody] KatBarang KatBarang)
        {
            try
            {
                await _KatBarang.UpdateAsync(KatBarang);
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
        public async Task<IActionResult> Post([FromBody] KatBarang KatBarang)
        {
            try
            {
                
                await _KatBarang.CreateAsync(KatBarang);
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
                await _KatBarang.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}