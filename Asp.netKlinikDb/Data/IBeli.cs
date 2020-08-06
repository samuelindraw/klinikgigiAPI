using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IBeli : ICrud<Beli>
    {
        Task<IEnumerable<Beli>> getbelibyidtenant(string TenantID);

    }
}
