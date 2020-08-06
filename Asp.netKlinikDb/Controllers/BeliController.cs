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
    public class BeliController : ControllerBase
    {
        private IBeli _Beli;
        private IBarang _Barang;
        private IDetailBeli _detailBeli;
        public  BeliController(IBeli Beli, IBarang Barang, IDetailBeli detailBeli)
        {
            _Beli = Beli;
            _Barang = Barang;
            _detailBeli = detailBeli;
        }
        // POST: api/Barangs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Beli beli)
        {
            try
            {
               
                await _Beli.CreateAsync(beli);
                return Ok("Tambah Data Berhasil");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Barang
        [HttpGet]
        //[Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<Beli>> GetBeli()
        {
            
            var models = await _Beli.GetAll();
           
            return models;
        }
        // PUT: api/Beli/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Beli Beli)
        {
            try
            {
               
                await _Beli.UpdateAsync(Beli);
                return Ok("Data berhasil diupdate");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Beli/5
        //beli get by id
        [HttpGet("{id}")]
        public async Task<Beli> Get(int id)
        {
            var model = await _Beli.GetById(id);
            return model;
        }
        // DELETE: api/Beli/5
        [HttpDelete("{id}")]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var databarang = await _detailBeli.sortbyidbeli(id);
                foreach (var barang in databarang)
                {
                    var getdetailpembelian = await _detailBeli.getbyid(barang.DetailBeliId);
                    var datadetailbarang = await _Barang.GetById(barang.IdBarang);

                    datadetailbarang.Stok = Convert.ToInt16(datadetailbarang.Stok - barang.Qty);
                    await _detailBeli.Deletes(getdetailpembelian.DetailBeliId);
                    await _Barang.UpdateAsync(datadetailbarang);

                }
                await _Beli.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getbelibytenant/{TenantID}")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        // GET: api/getbelibytenant/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // CEK apakah id kat barang sudah sesuai dengan Tenant
        // Pada client side ini nanti menggunakan dropdown yang listnya di sort menggunakan tenant yang di pilih user
        public async Task<IActionResult> getbelibyidtenant(string TenantID)
        {
            var model = await _Beli.getbelibyidtenant(TenantID);
            return Ok(model);

        }
    }
}