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
    public class DetailPasienController : ControllerBase
    {
        private IDetailPasien _DetailPasien;
        //private IBarang _Barang;

        public DetailPasienController(IDetailPasien detailPasien)
        {

            _DetailPasien = detailPasien;
        }
        // GET: api/DetailPasien
        [HttpGet]
        //[Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<DetailPasien>> GetDetailPasien()
        {

            var models = await _DetailPasien.GetAll();
            return models;
        }
        // GET: api/DetailPasien/5
        [HttpGet("getusername/{Username}")]
        //[Authorize(Roles = "Admin")]
        public async Task<DetailPasien> Getusername(string Username)
        {

            var model = await _DetailPasien.getusername(Username);
            return model;
        }
        // GET: api/DetailPasien/5
        [HttpGet("{IdPasien}")]
        public async Task<DetailPasien> Get(string Idpasien)
        {
            var model = await _DetailPasien.getbyidpasien(Idpasien);
            return model;
        }
        // POST: api/Barangs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetailPasien DetailPasien)
        {
            try
            {
                await _DetailPasien.CreateAsync(DetailPasien);
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
                await _DetailPasien.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/KatBarang/5
        [HttpDelete("{Username}")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> DeleteUser(string Username)
        {
            try
            {
                await _DetailPasien.DeleteByuser(Username);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/DetailPasien/5
        [HttpPut]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Put([FromBody] DetailPasien DetailPasien)
        {
            try
            {
                await _DetailPasien.UpdateAsync(DetailPasien);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}