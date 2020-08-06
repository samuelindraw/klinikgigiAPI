using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Barang
    {
        public Barang()
        {
            this.Beli = new List<Beli>();
            this.Jual = new List<Jual>();
            this.DetailBeli = new List<DetailBeli>();
           
        }
        [Key]
        public int IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public int Harga { get; set; }
        public short Stok { get; set; }
        public int IdKatBarang { get; set; }
        public string Keterangan { get; set; }
        public int  Minstok { get; set; }
        public int KatBarangIdKategori { get; set; }

        public KatBarang KatBarang { get; set; }
      
        public List<DetailBeli> DetailBeli { get; set; }
        public List<Beli> Beli { get; set; }
        public List<Jual> Jual { get; set; }
    }
}
