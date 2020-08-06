using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Tenant
    {
        [Key]
        public string TenantID { get; set; }
        public string TenantName { get; set; }
    }
}
