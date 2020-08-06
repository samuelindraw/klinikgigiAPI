using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class DetailPasien
    {
        public DetailPasien()
        {
            this.Transaksi = new List<Transaksi>();
            this.PesananGigiPalsu = new List<PesananGigiPalsu>();
        }
        [Key]
        public int DetailPasienID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Registrasi { get; set; }
        //penyakit di luar sakit gigi, misal mata plus, maag, alergi bla bla 
        public string RwPenyakit { get; set; }
        public string Username { get; set; }
        public string IdPasien { get; set; }
        public Pengguna Pengguna { get; set; }
        public IEnumerable<Transaksi> Transaksi { get; set; }
        public IEnumerable<PesananGigiPalsu> PesananGigiPalsu { get; set; }
    }
}
