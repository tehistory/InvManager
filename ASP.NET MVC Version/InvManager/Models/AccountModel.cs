using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvManager.Models
{
    public class AccountModel
    {
        public int accountID { get; set; }
        [Required]
        [MinLength(3)]
        [StringLength(100)]
        public string userName { get; set; }
        [Required]
        [MinLength(3)]
        [StringLength(100)]
        public string password { get; set; }
        [EmailAddress]
        [StringLength(100)]
        public string email { get; set; }

    }
}
