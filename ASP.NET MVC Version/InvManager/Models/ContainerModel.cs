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
        [Display(Name="Container Name")]
        public string containerName { get; set; }
        public string accountID { get; set; }
    }
}
