using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class PesananGigiPalsu
    {
        [Key]
        public int IdPesanan { get; set; }
        public DateTime TanggalPesan { get; set; }
        //ini isinya apaan ?
        public string JenisGigi { get; set; }
        //Username dari dokter yang mengisi data tindakan
        public string Username { get; set; }
        public string IdPasien { get; set; }
        public int HargaBeli { get; set; }  
        public int HargaJual { get; set; }
        //status pemesanan ? 
        public bool Status { get; set; }
        //status terpasang dan tidak terpasang true pr false
        public int? IdTindakanPesan { get; set; }
        //ini di isi apa
        public int IdTransaksiPasang { get; set; }
        public string Keterangan { get; set; }
        public string TenantID { get; set; }

        public Tenant Tenant { get; set; }
        public Pengguna Pengguna { get; set; }
    }
}
