using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IKatJenis : ICrud<KatJenis>
    {
        Task<IEnumerable<KatJenis>> getbytenantid(string tenantID);
    }
}
