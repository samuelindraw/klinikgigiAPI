using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IKatBarang : ICrud<KatBarang>
    {
        Task<IEnumerable<KatBarang>> getbytenantid(string TenantID);
        Task<IEnumerable<KatBarang>> sortbytenantandidkategori(string tenantID, string NamaKategori);

    }
}
