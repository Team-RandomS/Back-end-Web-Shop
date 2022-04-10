using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Technology.Models
{
    public class CTHD
    {
        public int soluong { get; set; }

        public Double gia { get; set; }

        [Required]
        public Product product { get; set; }

        public Donhang donhang { get; set; }

        [Key, Column(Order = 2)]
        public int Idproduct { get; set; }

        [Key, Column(Order = 1)]
        public int Iddonhang { get; set; }

    }
}