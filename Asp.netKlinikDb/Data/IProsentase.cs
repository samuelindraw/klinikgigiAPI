using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IProsentase : ICrud<Prosentase>
    {
        Task<IEnumerable<Prosentase>> getbytenantid(string tenantID);
        Task<IEnumerable<Prosentase>> getbyusername(string Username);
        Task Deletebyusername(string Username);
    }
}
