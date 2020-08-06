using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Transaksi
    {
        public Transaksi()
        {
            this.DetailPenggajian = new List<DetailPenggajian>();
            this.Jual = new List<Jual>();
            this.Tindakan = new List<Tindakan>();
        }
        //transaksi ini di isi oleh perawat lalu setelah itu muncul notif 
        // Harusnya muncul notif ke dokternya untuk mengisi tindakan 
        // cara menghubungkan ke dokter nya gimana ? apakah ke semua dokter dengan tenant yang sama ? lalu terserah dokter ingin mengisi atau tidak
        //(HANDLER ? ) DENGAN MENGGUNAKAN REAL TIME UPDATE ? SEKALI DI BUKA MAKA TIDAK BISA DI BUKA DOKTER LAIN , NOTIF HILANG ?
        // caranya dengan asign dokter yang di ada di tenant ini, diberi status juga agar ketika dokter telah mengisi resep maka otomatis status complete 
        // tidak bisa di isi lagi 
        //hanya boleh di isi oleh dokter tapi Perawat bisa baca 
        [Key]
        public int IdTransaksi { get; set; }
        public string IdPasien { get; set; }
        public string Username { get; set; }
        public DateTime Tanggal { get; set; }
        public string Anamnesis { get; set; }
        public string IdResep { get; set; }
        public string TenantID { get; set; }
        //otomatis terisi dari awal login di tampilkan tapi disabled ? kecuali oleh admin yang membetulkan jika ada salah ? 
        public Tenant Tenant { get; set; }
        public Pengguna Pengguna { get; set; }  
        //pie iki ?
        //Soon added as ienumerable
        public IEnumerable<DetailPenggajian> DetailPenggajian { get; set; }
        public IEnumerable<Jual> Jual { get; set; }
        public IEnumerable<Tindakan> Tindakan { get; set; }
    }
}
