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
    public class UserRoleController : ControllerBase
    {
        private IUserRole _userRoleService;
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRoleController(IUserRole userroleservice, UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userRoleService = userroleservice;
            _roleManager = roleManager;
        }
        [HttpPost]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Post([FromBody] UserRole userRole)
        {
            try
            {
                await _userRoleService.CreateRole(userRole);
                return Ok("Tambah Role Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/KatBarang/5
        [HttpPut]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Put([FromBody] UserRole userRole)
        {
            try
            {
                await _userRoleService.Edit(userRole);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/UserRole/5
        [HttpGet("{roleName}", Name = "GetbyRoleName")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<UserRole> Get(string roleName)
        {
            var model = await _userRoleService.GetById(roleName);
            return model;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IEnumerable<UserRole>>GetRoles()
        {

            var models = await _userRoleService.GetAllRoles();
            return models;
        }
        [HttpGet]
        [Route("GetUserRole")]
        //[Authorize(Roles = "Admin")]
        // Get: api/GetUserRole/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // Use ActionResult jika anda ingin pass data dari client melalui parameter
        public async Task<IActionResult> GetUserRole(string roleName)
        {
            var model = await _userRoleService.GetUserRole(roleName);
            return Ok(model);

        }
        [HttpDelete("{roleName}")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Delete(string roleName)
        {
            try
            {
                await _userRoleService.DeleteRolesAsync(roleName);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [Route("addusertorole")]
        public async Task<IActionResult> AddUserToRole([FromBody] Users user)
        {

            try
            {

                await _userRoleService.AddUserToRoleAsync(user.Username, user.rolename);
                return Ok("User yang telah di masukan ke role ini Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [Route("editusertorole")]
        public async Task<IActionResult> EditUserToRole([FromBody] Users user)
        {

            try
            {
                await _userRoleService.RemoveuserRole(user.Username, user.currentrole);
                await _userRoleService.AddUserToRoleAsync(user.Username, user.rolename);
                return Ok("User yang telah berhasil edit dan di pindah ke role ini Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        [Route("removeuserrole")]
        public async Task<IActionResult> removeuserrole([FromBody] Users user)
        {
         
            try
            {
                await _userRoleService.RemoveuserRole(user.Username, user.rolename);
                return Ok("User telah di delete dari role ini ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        //[HttpPost]
        ////[Authorize(Roles = "Admin")]
        //[Route("deleteuserrole")]
        //public async Task<IActionResult> Deleteuserrole([FromBody] User user)
        //{

        //    try
        //    {
        //        await _userRoleService.(user.Username, user.rolename);
        //        return Ok("User yang telah di masukan ke role ini Berhasil");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }


        //}
    }
}