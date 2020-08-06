using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Asp.netKlinikDb.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUser _userService;
        private IUserRole _roleService;
        private IPengguna _Pengguna;
        private IDetailPasien _detailPasien;
        private IDetailPegawai _detailPegawai;
        private ITenantPengguna _tenantPengguna;


        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public UserController(IUser userService, UserManager<ApplicationUser> userManager, 
            IPengguna pengguna, IDetailPasien detailpasien, IDetailPegawai detailPegawai, ITenantPengguna tenantPengguna)
        {
            _userManager = userManager;
            _userService = userService;
            _Pengguna = pengguna;
            _detailPasien = detailpasien;
            _detailPegawai = detailPegawai;
            _tenantPengguna = tenantPengguna;
        

        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody]Users userParam)
        {
            try
            {
                var user = await _userService.Authenticate(userParam.Username, userParam.Password, userParam.TenantID);
                if (user == null)
                {
                    return BadRequest("Username atau Password anda Salah !!");
                }
                // kenapa menggunkan user yang merupaka output dari authenticate ? supaya tau klo usernya ada //doublecheck
                // menggunakan handler bahwa 1 usernama hanya akan ada di 1 tenant yang sama tetpi bisa  di tenant yang lain ...
                var tenant = await _userService.tenantforusername(userParam.TenantID, user.Username);
                if (tenant == null)
                {
                    return BadRequest("Anda tidak terdaftar di tenant ini ");
                }
                else
                {
                    user.TenantID = tenant.TenantID;
                    user.TenantName = tenant.Tenant.TenantName;
                    Pengguna updatetenant = new Pengguna();
                    updatetenant.Username = user.Username;
                    updatetenant.TenantID = tenant.TenantID;
                    await _Pengguna.Updatetenant(updatetenant);
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] Users userModel)
        {
            try
            {
                //test nanti di pindah ke DAL
                await _userService.Register(userModel);
                await _userService.AddUserToRole(userModel);
                //ambil data role dari yang udah ada 
                // masukan ke pengguna....
                Pengguna pengguna = new Pengguna();
                pengguna.Username = userModel.Username;
                pengguna.Email = userModel.Email;
                pengguna.TenantID = userModel.TenantID;
                pengguna.rolename = userModel.rolename;
                ////test it will it be okey if there same username again ? 
               
                if (userModel.rolename == "Pasien")
                {
                    pengguna.IdPasien = new Guid().ToString();
                    await _userService.addpengguna(pengguna);
                    DetailPasien detailpasien = new DetailPasien();
                    detailpasien.Registrasi = DateTime.Today;
                    detailpasien.IdPasien = pengguna.IdPasien;
                    detailpasien.Username = pengguna.Username;
                    await _detailPasien.CreateAsync(detailpasien);
                }
                else
                {
                    pengguna.IdPasien = null;
                    var tenant = userModel.TenantID;
                    pengguna.TenantID = tenant;
                    await _userService.addpengguna(pengguna);
                    DetailPegawai detailPegawai = new DetailPegawai();
                    detailPegawai.Username = pengguna.Username;
                    detailPegawai.TanggalJoin = DateTime.Today;
                    detailPegawai.Jabatan = userModel.rolename;
                    await _detailPegawai.CreateAsync(detailPegawai);
                }
                TenantPengguna tenantPengguna = new TenantPengguna();
                tenantPengguna.Username = userModel.Username;
                tenantPengguna.TenantID = userModel.TenantID;
                await _userService.TenantPengguna(tenantPengguna);
                return Ok("Pendaftaran Anda Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getall")]
        //[Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Users>> GetUsers()
        { 

            var models = await _userService.GetAll();
           
            return models;
        }
        [HttpPut]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Put([FromBody] Users userModel)
        {
            try
            {
                await _userService.Updateuser(userModel);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Enable/{Username}")]
        //[Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Enabled([FromBody] Users userModel)
        {
            try
            {
                Users users = new Users();
                ApplicationUser user = new ApplicationUser();
                user = await _userService.GetbyUsername(userModel.Username);
                users.Username = user.UserName;
                if(user.IsEnabled == true)
                {
                   
                    users.IsEnabled = false;
                }
                else
                {
                    users.IsEnabled = true;
                }
                await _userService.EnableDisableduser(users);
                return Ok("Status Users diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/User/5
        [HttpGet("getuserbyusername/{userName}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ApplicationUser> Get(string userName)
        {
            var model = await _userService.GetbyUsername(userName);
            return model;
        }
        //[HttpGet]
        //[Route("GetUserRole")]
        ////[Authorize(Roles = "Admin")]
        //// Get: api/GetUserRole/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        //// Use ActionResult jika anda ingin pass data dari client melalui parameter
        //public async Task<IActionResult> GetUserRole(string roleName)
        //{
        //    var model = await _userRoleService.GetUserRole(roleName);
        //    return Ok(model);

        //}
        //FIGURE IT OUT WHY IT NOT WORK ALREADY ? 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Data berhasil logout");
        }
        // DELETE: api/User/5
        // masih manual optional untuk jaga jaga jika data ingin di delete permanen 
        [HttpDelete("{Username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string Username)
        {
            try
            {
                
                
                Pengguna pengguna = new Pengguna();
                pengguna = await _Pengguna.getpenggunausername(Username);
                if(pengguna.rolename == "Pasien")
                {
                    var cekpasien = await _detailPasien.getusername(Username);
                    if (cekpasien != null)
                    {
                        await _detailPasien.DeleteByuser(Username);
                    }
                    
                }
                else
                {
                    //prosentase soon aded
                    //detail gaji to
                    //pengajian
                    var cekpegawai = await _detailPegawai.getusername(Username);
                    if(cekpegawai != null)
                    {
                        await _detailPegawai.DeleteByuser(Username);
                    }
                  
                }
                var tenant = await _tenantPengguna.getusertenantlist(Username);
                foreach(var data in tenant )
                {
                    await _tenantPengguna.Delete(data.TenantPenggunaID);
                }
                await _Pengguna.DeletebyUser(pengguna.Username);
                await _userService.Delete(Username);


                //delete data pengguna sekalian 
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}