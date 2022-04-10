using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Technology.Models;

namespace Web_Technology.ViewModel
{
    public class ProductViewModel
    {
        public string Productname { get; set; }
        public Double gia { get; set; }
        public string Imagepicture { get; set; }

        public int Idgory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}