using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IDetailPegawai : ICrud<DetailPegawai>
    {
        Task<DetailPegawai> getusername(string Username);
        Task DeleteByuser(string Username);
    }
}
