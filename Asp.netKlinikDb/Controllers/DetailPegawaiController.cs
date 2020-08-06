using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailPegawaiController : ControllerBase
    {
        private IDetailPegawai _DetailPegawai;
        //private IBarang _Barang;

        public DetailPegawaiController(IDetailPegawai detailPegawai)
        {

            _DetailPegawai = detailPegawai;
        }
        // GET: api/DetailPasien
        [HttpGet]
        //[Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<DetailPegawai>> GetDetailPegawai()
        {

            var models = await _DetailPegawai.GetAll();
            return models;
        }
        // GET: api/DetailPegawai/5 
        [HttpGet("{Username}")]
        //[Authorize(Roles = "Admin")]
        public async Task<DetailPegawai> Get(string Username)
        {

            var model = await _DetailPegawai.getusername(Username);
            return model;
        }
        // POST: api/Barangs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetailPegawai DetailPegawai)
        {
            try
            {
                await _DetailPegawai.CreateAsync(DetailPegawai);
                return Ok("Tambah Data Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/KatBarang/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _DetailPegawai.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/DetailPegawai/5
        [HttpPut]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Put([FromBody] DetailPegawai DetailPegawai)
        {
            try
            {
                await _DetailPegawai.UpdateAsync(DetailPegawai);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}