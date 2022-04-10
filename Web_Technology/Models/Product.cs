using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Technology.Models
{
    public class Product
    {
        [Key]
        public int Idproduct { get; set; }

        [Required]
        [StringLength(255)]
        public string Productname { get; set; }

        [Required]
        public Double gia { get; set; }

        [Required]
        [StringLength(255)]
        public string Imagepicture { get; set; }

        public Category Category { get; set; }

        [Required]
        public int Idgory { get; set; }
    }
}