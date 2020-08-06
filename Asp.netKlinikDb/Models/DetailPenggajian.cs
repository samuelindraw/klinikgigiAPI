using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class DetailPenggajian
    {
        [Key]
        public int IdDetailGaji { get; set; }
        public int IdGaji { get; set; }
        public int IdTransaksi { get; set; }
        public Penggajian Penggajian { get; set; }
        public Transaksi Transaksi { get; set; }
    }
}
