using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Technology.Models
{
    public class Khachhang
    {
        [Key]
        public int Idkhach { get; set; }

        [Required]
        [StringLength(255)]
        public string hoten { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string matkhau { get; set; }

        [StringLength(255)]
        public string diachi { get; set; }

        [StringLength(255)]
        public string dienthoai { get; set; }
    }
}