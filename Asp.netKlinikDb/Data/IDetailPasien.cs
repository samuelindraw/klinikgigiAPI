using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IDetailPasien : ICrud<DetailPasien>
    {
        Task<DetailPasien> getbyidpasien(string IdPasien);
        Task DeleteByuser(string Username);
        Task<DetailPasien> getusername(string Username);
    }
}
