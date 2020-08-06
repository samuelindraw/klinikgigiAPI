using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IJenisTindakan : ICrud<JenisTindakan>
    {
        Task<IEnumerable<JenisTindakan>> getbytenantid(string tenantID);
    }
}
