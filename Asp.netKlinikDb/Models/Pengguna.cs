using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Pengguna
    {
        public Pengguna()
        {

            this.Transaksi = new List<Transaksi>();
            this.PesananGigiPalsu = new List<PesananGigiPalsu>();
            this.TenantPengguna = new List<TenantPengguna>();


        }
        [Key]
        public string Username { get; set; }
        //id pasien terpakai di berbagai table seperti pengguna,transaksi,tindakan,pemesanan gigi palsu 
        // di hide ketika emang kosong
        public string IdPasien { get; set; }
        public string Nama { get; set; }
        public string Gender { get; set; }
        public short Umur { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string NoTelpon { get; set; }
        public string NoHP { get; set; }
        public string rolename { get; set; }
        //current role nampung role lama sebelum di update
        public string Email { get; set; }
        public string TenantID { get; set; }

        public Tenant Tenant { get; set; }

        public IEnumerable<Transaksi> Transaksi { get; set; }
        public IEnumerable<PesananGigiPalsu> PesananGigiPalsu { get; set; }
        public IEnumerable<TenantPengguna> TenantPengguna { get; set; }
        public DetailPasien detailPasien { get; set; }
    }
}
