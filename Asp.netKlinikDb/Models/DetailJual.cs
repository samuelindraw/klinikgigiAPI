using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class DetailJual
    {
        [Key]
        public string DetailJualId { get; set; }
        public int IdJual { get; set; }
        public int IdBarang { get; set; }
        public short Qty { get; set; }
        public int Harga { get; set; }


        public Barang Barang { get; set; }
        public Beli beli { get; set; }
    }
}
