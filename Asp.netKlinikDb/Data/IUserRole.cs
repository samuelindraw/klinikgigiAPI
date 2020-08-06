using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IUserRole
    {
        Task CreateRole(UserRole userRole);
        Task Edit(UserRole userRole);
        Task AddUserToRoleAsync(string username, string role);
        Task RemoveuserRole(string username, string role);
        Task<bool> CheckUserInRoleAsync(string username, string rolename);
        Task DeleteRolesAsync(string roleName);
        Task<IEnumerable<UserRole>> GetAllRoles();
        Task<IEnumerable<Users>>GetUserRole(string roleName);
        Task<UserRole>GetById(string roleName);
    }
}
