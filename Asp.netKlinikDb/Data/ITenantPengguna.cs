using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface ITenantPengguna : ICrud<TenantPengguna> 
    {
        Task<TenantPengguna> GetbyTenantPenggunaID(string Id);
        Task<TenantPengguna> tenantforusername(string tenantID, string username);
        Task<IEnumerable<TenantPengguna>> getusertenantlist(string Username);
        Task<IEnumerable<TenantPengguna>> getuserbytenantid(string tenantID);
        Task Delete(string id);
    }
}
