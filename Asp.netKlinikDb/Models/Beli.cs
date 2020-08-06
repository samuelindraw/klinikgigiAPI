using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Beli
    {
        // kalau stok barang habis munculkan notif ke perawat/admin ada stok yang mau habis ? < 3
        [Key]
        public int IdBeli { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Tanggal { get; set; }
        public string NamaPembelian { get; set; }
        public string Keterangan { get; set; }
        public string TenantID { get; set; }
        //pembelian di berikan dengna total harga ?
        // count data pembeian dari setiap detail beli ? 
        public int TotalHarga { get; set; }
        public Tenant Tenant { get; set; }
      
    }
}
