using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Technology.Models
{
    public class Category
    {
        [Key]
        public int Idgory { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}