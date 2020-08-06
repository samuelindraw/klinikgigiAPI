using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class JenisTindakan
    {
        public JenisTindakan()
        {
            this.Prosentase = new List<Prosentase>();
            this.Tindakan = new List<Tindakan>();
        }
        [Key]
        public int IdJenisTindakan { get; set; }
        public int IdKatJenis { get; set; }
        //jenis nama tindakan 
        public string Jenis { get; set; }
        //lait di database
        public int Biaya { get; set; }
        public int? BiayaKelipatan { get; set; }
        //sengaja contoh sebagai contoh     
        public string Keterangan { get; set; }
        public string TenantID { get; set; }

        public Tenant Tenant { get; set; }
        public KatJenis KatJenis { get; set; }
        //penggunaan ienumberable hmm
        public IEnumerable<Prosentase> Prosentase { get; set; }
        public IEnumerable<Tindakan> Tindakan { get; set; }
    }
}
