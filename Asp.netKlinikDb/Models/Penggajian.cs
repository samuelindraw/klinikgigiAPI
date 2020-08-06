using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Penggajian
    {
        public Penggajian()
        {
            this.DetailPenggajian = new List<DetailPenggajian>();
        }
        [Key]
        public int IdGaji { get; set; }
        public string Username { get; set; }

        //ini tanggal gaji maksutnya apa 
        public DateTime TanggalGaji { get; set; }
        
        //tanggal awal dan akhir apaan ? 
        public DateTime? TanggalAwal { get; set; }
        public DateTime? TanggalAkhir { get; set; }
        public int TotalGaji { get; set; }
        public string MasaWaktu { get; set; }
        public string TenantID { get; set; }

        public Tenant Tenant { get; set; }
        public Pengguna Pengguna { get; set; }
        public IEnumerable<DetailPenggajian> DetailPenggajian { get; set; }
    }
}
