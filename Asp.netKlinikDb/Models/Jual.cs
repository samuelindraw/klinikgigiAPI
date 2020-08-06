using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Jual
    {
        // kalau ada resep munculkan notif ke perawat yang mengisi penjualan ? 
        // previous data transaksi yang di isi ? atau tindakan ? 
        [Key]
        public int IdJual { get; set; }
        public int IdTransaksi { get; set; }
        public string NamaPenjualan { get; set; }
        public string TenantID { get; set; }

        public Tenant Tenant { get; set; }
        public Transaksi Transaksi { get; set; }
    }
}
