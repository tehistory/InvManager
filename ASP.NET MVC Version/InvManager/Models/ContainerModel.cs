using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InvManager.Models
{
    public class ContainerModel
    {
        [Key]
        public int containerID { get; set; }
        [Required]
        [StringLength(50)]
        public string containerName { get; set; }
        public int accountID { get; set; }
    }
}
