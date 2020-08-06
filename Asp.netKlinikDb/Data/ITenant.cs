using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface ITenant : ICrud<Tenant>
    {
        Task<Tenant> Getbytenantname(string tenantname);
        Task<Tenant> GetbytenantID(string tenantID);
        Task Delete(string id);
    }
}
