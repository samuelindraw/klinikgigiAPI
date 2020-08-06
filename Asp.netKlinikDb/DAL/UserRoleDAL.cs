using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class UserRoleDAL : IUserRole
    {
       
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private AppDbContext _context;

        public UserRoleDAL(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, AppDbContext context, SignInManager<ApplicationUser> signInManager)
        {
           
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
        }

        public async Task AddUserToRoleAsync(string username, string role)
        {
            //USER ONLY CAN ONLY REGISTERED INTO ONE ROLE ONLY
            //COUNTING USER ROLE IF MORE THAN ZERO WHICH THAT MEANS USER HAVE ROLE 
            var user = await _userManager.FindByNameAsync(username);
            var check = await _userManager.GetRolesAsync(user);
            if (check.Count == 0)
            {
                try
                {
                    await _userManager.AddToRoleAsync(user, role);


                }
                catch (Exception ex)
                {
                    throw new Exception($"Error {ex.Message}");
                }

            }
            else
            {
                throw new Exception("User sudah berada dalam role lain");
            }

        }
        public async Task RemoveuserRole(string username, string rolename)
        {
            //USER ONLY CAN ONLY REGISTERED INTO ONE ROLE ONLY
            //COUNTING USER ROLE IF MORE THAN ZERO WHICH THAT MEANS USER HAVE ROLE 
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                try
                {
                    var check = await _userManager.RemoveFromRoleAsync(user, rolename);
                   

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data role tidak ditemukan");
            }

        }


        public async Task<bool> CheckUserInRoleAsync(string username, string rolename)
        {
            var user = await _userManager.FindByNameAsync(username);
            var check = await _userManager.IsInRoleAsync(user, rolename);
            return check;
        }

        public async Task CreateRole(UserRole userRole)
        {
            //IdentityResult roleResult;
            var roleExist = await _roleManager.RoleExistsAsync(userRole.RoleName);
            if(roleExist == false)
            {
                var user = new IdentityRole { Name = userRole.RoleName };
                var result = await _roleManager.CreateAsync(user);
                if (!result.Succeeded)
                    throw new Exception("Gagal menambah Role");
            }
            else
            {
                throw new Exception("Role sudah ada gagal menambah role");
            }
          
        }

        public async Task DeleteRolesAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role != null)
            {
                try
                {
                    await _roleManager.DeleteAsync(role);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data role tidak ditemukan");
            }
        }

        public async Task<IEnumerable<UserRole>> GetAllRoles()
        {
            var data = await(from r in _context.Roles
                             orderby r.Name ascending
                             select r).ToListAsync();

            var role = (from roles in data
                        select new UserRole
                        {
                            RoleID = roles.Id,
                            RoleName = roles.Name,

                        }).ToList();

            return role;
        }

        public async Task<IEnumerable<Users>> GetUserRole(string Nama)
        {

            var userrolelist = await _userManager.GetUsersInRoleAsync(Nama);
            
            var list = (from user in userrolelist
                        select new Users
                        {
                            Id = user.Id,
                            Username = user.UserName,
                            Email = user.Email,
                            rolename = Nama
                           
                        }).ToList();

            list.Select(async user =>
            {
                var userEntity = await _userManager.FindByIdAsync(user.Id);
                user.rolename = string.Join("; ", await _userManager.GetRolesAsync(userEntity));
            }).ToList();

            return list;
        }
        public async Task<UserRole> GetById(string roleID)
        {
            var userFind = await _roleManager.FindByNameAsync(roleID);

            var role = new UserRole
            {
                RoleID = userFind.Id,
                RoleName = userFind.Name


            };
            return role;
        }

        public async Task Edit(UserRole userRole)
        {
            var role = await _roleManager.FindByIdAsync(userRole.RoleID);
            if (role != null)
            {
                try
                {
                    role.Name = userRole.RoleName;
                    await _roleManager.UpdateAsync(role);
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message} {ex.InnerException.Message}");
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan");
            }
        }
    }
}
