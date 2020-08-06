using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IDetailBeli : ICrud<DetailBeli> 
    {
        Task<DetailBeli> getbyid(string tenantname);
        Task Deletes(string id);
        Task<IEnumerable<DetailBeli>> sortbyidbeli(int IdBeli);
    }
}
