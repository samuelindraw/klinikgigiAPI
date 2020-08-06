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
    public class DetailBeliController : ControllerBase
    {
        private IDetailBeli _DetailBeli;
        private IBarang _Barang;

        public DetailBeliController(IDetailBeli DetailBeli, IBarang Barang)
        {
           
            _DetailBeli = DetailBeli;
            _Barang = Barang;
        }
        // POST: api/DetailBeli
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetailBeli DetailBeli)
        {
            try
            {
                await _DetailBeli.CreateAsync(DetailBeli);
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
        public async Task<IEnumerable<DetailBeli>> getdetailid()
        {

            var models = await _DetailBeli.GetAll();

            return models;
        }
        // GET: api/DetailBeli/5
        [HttpGet("sortbeliid/{id}")]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> sortbeliid(int Id)
        {

            var model = await _DetailBeli.sortbyidbeli(Id);
            return Ok(model);

        }
        // GET: api/Detailbeli/5
        //DetailBeli get by id
        [HttpGet("{id}")]
        public async Task<DetailBeli> Get(string id)
        {
            var model = await _DetailBeli.getbyid(id);
            return model;
        }
        // DELETE: api/DetailBeli/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var data = await _DetailBeli.getbyid(id);
                var databarang = await _Barang.GetById(data.IdBarang);

                databarang.Stok = Convert.ToInt16(databarang.Stok - data.Qty);
                await _DetailBeli.Deletes (id);
                await _Barang.UpdateAsync(databarang);

                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Beli/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] DetailBeli detailBeli)
        {
            try
            {
                var data = await _Barang.GetById(detailBeli.IdBarang);
                data.Stok = Convert.ToInt16(detailBeli.Qty + data.Stok);
                await _DetailBeli.UpdateAsync(detailBeli);
                await _Barang.UpdateAsync(data);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}