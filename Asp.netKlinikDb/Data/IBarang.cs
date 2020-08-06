using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IBarang : ICrud<Barang>
    {
        Task<Barang> getbykatbarangid(int IdKatBarang);
        Task<Barang> getbyNamaBarang(string NamaBarang);
        Task<IEnumerable<Barang>> getbytenantid(string tenantID);
        Task<IEnumerable<Barang>> getkatbarangsid(int IdKatBarang);
        Task<IEnumerable<Barang>> sortbystok(string tenantID);



    }
}
