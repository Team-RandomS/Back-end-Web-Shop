using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Technology.Models
{
    public class Giohang
    {
        ApplicationDbContext data = new ApplicationDbContext();
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string productname { get; set; }
        [Display(Name = "Giá")]
        public Double gia { get; set; }
        [Display(Name = "Hình ảnh")]
        public string hinh { get; set; }
        [Display(Name = "Số lượng")]
        public int soluong { get; set; }
        [Display(Name = "Tổng tiền")]
        public Double thanhtien
        {
            get { return soluong * gia; }

        }
        public Giohang(int id)
        {
            this.Id = id;
            Product product = data.Products.Single(n => n.Idproduct == id);
            productname = product.Productname;
            gia = product.gia;
            hinh = product.Imagepicture;
            soluong = 1;
        }
    }
}