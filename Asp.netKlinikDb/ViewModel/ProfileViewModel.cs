using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.ViewModel
{
    public class ProfileViewModel
    {
        [Key]
        public string Username { get; set; }
        public string currentrole { get; set; }
        public string Email { get; set; }
        public string gender { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}
