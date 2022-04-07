using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InvManager.Models
{
    public class ItemModel
    {
        [Key]
        public int itemID { get; set; }
        public int containerID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Item Name")]
        public string itemName { get; set; }
    }
}
