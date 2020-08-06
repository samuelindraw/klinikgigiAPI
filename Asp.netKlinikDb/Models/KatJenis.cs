using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class KatJenis
    {
        public KatJenis()
        {
            this.JenisTindakan = new List<JenisTindakan>();
        }
        [Key]
        public int IdKatJenis { get; set; }
        public string KategoriName { get; set; }
        public string TenantID { get; set; }

        public Tenant Tenant { get; set; }
        public IEnumerable<JenisTindakan> JenisTindakan { get; set; }
    }
}
