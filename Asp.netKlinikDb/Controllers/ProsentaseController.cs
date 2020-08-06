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
    public class ProsentaseController : ControllerBase
    {
        private IProsentase _Prosentase;
        private IBarang _Barang;

        public ProsentaseController(IProsentase prosentase, IBarang Barang)
        {

            _Prosentase = prosentase;
            _Barang = Barang;
        }
        // POST: api/Prosentase
        [HttpPost]
        [Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Post([FromBody] Prosentase Prosentase)
        {
            try
            {
                await _Prosentase.CreateAsync(Prosentase);
                return Ok("Tambah Data Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Barang
        [HttpGet("getbytenantid/{tenantID}")]
        //[Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<Prosentase>> getbytenantid(string tenantID)
        {

            var models = await _Prosentase.getbytenantid(tenantID);
            return models;
        }
        // GET: api/DetailBeli/5
        [HttpGet("getbyusername/{Username}")]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> getbyusername(string Username)
        {

            var model = await _Prosentase.getbyusername(Username);
            return Ok(model);

        }
        // DELETE: api/Prosentase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Prosentase.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("deletebyusername/{Username}")]
        public async Task<IActionResult> deletebyusername(string Username)
        {
            try
            {
                await _Prosentase.Deletebyusername(Username);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Prosentase/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Prosentase Prosentase)
        {
            try
            {
                await _Prosentase.UpdateAsync(Prosentase);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Peosentase
        [HttpGet]
        [Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<Prosentase>> GetBarang()
        {

            var models = await _Prosentase.GetAll();
            return models;
        }

    }
}