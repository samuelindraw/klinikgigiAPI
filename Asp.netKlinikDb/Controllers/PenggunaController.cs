using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenggunaController : ControllerBase
    {
        private IPengguna _Pengguna;
        private IUserRole _UserRole;
        private IUser _userService;
        private ITenantPengguna _tenantPengguna;


        public PenggunaController(IUser userService, IPengguna pengguna, IUserRole userRole, ITenantPengguna tenantPengguna)
        {
            _Pengguna = pengguna;
            _UserRole = userRole;
            _userService = userService;
            _tenantPengguna = tenantPengguna;
            
        }
        // GET: api/Tenant
        [HttpGet]
        public async Task<IEnumerable<Pengguna>> getall()
        {
            
            var Models = await _Pengguna.GetAll();
            //foreach(var data in Models)
            //{
                
            //}
            return Models;
        }
        // POST: api/Pengguna
        [HttpPost]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        
        public async Task<IActionResult> Post([FromBody] Pengguna pengguna)
        {
            try
            {
                    await _Pengguna.CreateAsync(pengguna);
                    return Ok("Tambah Data Berhasil");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/User/5
        [HttpGet("getpenggunausername/{Username}")]
        //[Authorize(Roles = "Admin")]
        public async Task<Pengguna> Get(string Username)
        {

            var model = await _Pengguna.getpenggunausername(Username);
            var usertenantlist = await _tenantPengguna.getusertenantlist(Username);
            model.TenantPengguna = usertenantlist;
            
            return model;
        }
        [HttpGet("getusername/{Username}")]
        //[Authorize(Roles = "Admin")]
        public async Task<Pengguna> getusername(string Username)
        {

            var model = await _Pengguna.getusername(Username);


            return model;
        }
        [HttpGet("getpasien/{tenantID}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Pengguna>> getpasien(string tenantID, string rolename)
        {
            //tenantID = "513be315-a29f-4404-ace5-bf9c19410982";
            rolename = "Pasien";
            var model = await _Pengguna.datapasien(tenantID, rolename);
            return model;
        }
        // PUT: api/Pengguna/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Pengguna Pengguna)
        {
            try
            {

                // username dan email yang di ganti ke identity user 
                // username g bisa di ganti ? yes
                //email bisa ? yes
              
                await _Pengguna.UpdateAsync(Pengguna);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Pengguna/5
        [HttpDelete("{id}")]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _Pengguna.DeletebyUser(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}