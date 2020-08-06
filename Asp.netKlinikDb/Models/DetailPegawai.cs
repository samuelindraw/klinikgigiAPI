using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class DetailPegawai
    {
        public DetailPegawai()
        {

            this.Penggajian = new List<Penggajian>();
            this.Prosentase = new List<Prosentase>();
        }
               
        [Key]
        //change type data later....
        public int DetailPegawaiID { get; set; }
        public string Jabatan { get; set; }
        public int Gaji { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TanggalJoin { get; set; }   

        public string Username { get; set; }
        public Pengguna Pengguna { get; set; }
        public IEnumerable<Penggajian> Penggajian { get; set; }
        public IEnumerable<Prosentase> Prosentase { get; set; }
    }
}
