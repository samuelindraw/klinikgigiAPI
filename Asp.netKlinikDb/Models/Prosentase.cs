using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Prosentase
    {
        [Key]
        public int IdProsentase { get; set; }
        public string Username { get; set; }
        //public string DetailPegawaiID { get; set; }
        public int IdJenisTindakan { get; set; }
        public double Prosen { get; set; }
        public string TenantID { get; set; }

        public Tenant Tenant { get; set; }
        public Pengguna Pengguna { get; set; }
        public JenisTindakan JenisTindakan { get; set; }

    }
}
