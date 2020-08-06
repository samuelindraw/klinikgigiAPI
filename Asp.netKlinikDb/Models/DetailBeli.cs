using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class DetailBeli
    {
        [Key]
        public string DetailBeliId { get; set; }
        public int IdBeli { get; set; }
        public DateTime Tanggal { get; set; }
        public int IdBarang { get; set; }
        public short Qty { get; set; }
        public int Harga { get; set; }
        public int TotalHarga { get; set; }


        public Barang Barang { get; set; }
        public Beli beli { get; set; }
    }
}
