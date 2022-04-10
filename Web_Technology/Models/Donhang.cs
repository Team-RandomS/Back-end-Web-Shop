using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Technology.Models
{
    public class Donhang
    {

        [Key]
        public int Iddonhang { get; set; }

        [Required]
        public DateTime ngaydat { get; set; }

        public DateTime ngaygiao { get; set; }

        public Khachhang khach { get; set; }

        [Required]
        public int Idkhach { get; set; }
    }
}