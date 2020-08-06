using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IPengguna : ICrud<Pengguna>
    {
        Task<Pengguna> getpenggunausername(string Username);
        Task<Pengguna> getusername(string Username);
        Task DeletebyUser(string Username);
        Task Updatetenant(Pengguna obj);

        Task<IEnumerable<Pengguna>> datapasien(string tenantID, string rolename);
    }
}
