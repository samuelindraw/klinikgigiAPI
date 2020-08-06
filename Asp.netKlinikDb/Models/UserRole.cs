using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class UserRole
    {
        [Key]
        public string RoleID { get; set; }
        public string RoleName { get; set; }
      

    }
}
