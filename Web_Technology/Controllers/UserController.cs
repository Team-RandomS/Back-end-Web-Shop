using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Technology.Models;

namespace Web_Technology.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext data = new ApplicationDbContext();
        // GET: User
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Dangky(FormCollection cls, Khachhang kh)
        {
            var tenkhach = cls["hoten"];
            var email = cls["email"];
            var mk = cls["matkhau"];
            var diachi = cls["diachi"];
            var sdt = cls["dienthoai"];
            if (string.IsNullOrEmpty(tenkhach) || string.IsNullOrEmpty(email))
            {
                ViewData["Error"] = "Không được để trống";
            }
            else
            {
                kh.hoten = tenkhach;
                kh.email = email;
                kh.matkhau = mk;
                kh.diachi = diachi;
                kh.dienthoai = sdt;
                data.Khachhangs.Add(kh);
                data.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            return this.Dangky();
        }
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection cls)
        {
            var email = cls["email"];
            var mk = cls["matkhau"];
            var check = data.Khachhangs.FirstOrDefault(n => n.email == email && n.matkhau == mk);
            if (check != null)
            {
                Session["TaiKhoan"] = check;
                ViewBag.ten = check.hoten;
            }
            else
            {
                ViewData["Login"] = "Email hoặc mật khẩu không hợp lệ";
            }
            return RedirectToAction("Index", "Product");
        }
    }
}