using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class KatBarang
    {
        public KatBarang()
        {
            this.Barang = new List<Barang>();
        }
        [Key]
        public int IdKategori { get; set; }
        public string NamaKategori { get; set; }
        public string TenantID { get; set; }

        public List<Barang> Barang { get; set; }
        public Tenant Tenant { get; set; }
    }
}
