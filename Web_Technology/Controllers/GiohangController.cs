using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Technology.Models;

namespace Web_Technology.Controllers
{
    public class GiohangController : Controller
    {
        // GET: Giohang
        ApplicationDbContext data = new ApplicationDbContext();

        public List<Giohang>Laygiohang()
        {
            List<Giohang> lgiohang = Session["Giohang"] as List<Giohang>;
            if (lgiohang == null)
            {
                lgiohang = new List<Giohang>();
                Session["Giohang"] = lgiohang;
            }
            return lgiohang;
        }

        public ActionResult ThemGioHang(int id, string strURL)
        {
            List<Giohang> lgiohang = Laygiohang();
            Giohang sp = lgiohang.Find(n => n.Id == id);
            if (sp == null)
            {
                sp = new Giohang(id);
                lgiohang.Add(sp);
                return Redirect(strURL);
            }
            else
            {
                sp.soluong++;
                return Redirect(strURL);
            }
        }

        private int Tongsoluong()
        {
            int tsl = 0;
            List<Giohang> lgiohang = Session["Giohang"] as List<Giohang>;
            if (lgiohang != null)
            {
                tsl = lgiohang.Sum(n => n.soluong);
            }
            return tsl;
        }
        private int Tongsoluongsanpham()
        {
            int tsl = 0;
            List<Giohang> lgiohang = Session["Giohang"] as List<Giohang>;
            if (lgiohang != null)
            {
                tsl = lgiohang.Count();
            }
            return tsl;
        }

        private double Tongtien()
        {
            double tt = 0;
            List<Giohang> lgiohang = Session["Giohang"] as List<Giohang>;
            if (lgiohang != null)
            {
                tt = lgiohang.Sum(n => n.thanhtien);
            }
            return tt;
        }

        public ActionResult GioHang()
        {
            List<Giohang> lgiohang = Laygiohang();
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            ViewBag.Tongsoluongsanpham = Tongsoluongsanpham();
            return View(lgiohang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            ViewBag.Tongsoluongsanpham = Tongsoluongsanpham();
            return PartialView();
        }

        public ActionResult XoaGiohang(int id)
        {
            List<Giohang> lgiohang = Laygiohang();
            Giohang sp = lgiohang.SingleOrDefault(n => n.Id == id);
            if (sp != null)
            {
                lgiohang.RemoveAll(n => n.Id == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapnhatGiohang(int id, FormCollection cls)
        {
            List<Giohang> lgiohang = Laygiohang();
            Giohang sp = lgiohang.SingleOrDefault(n => n.Id == id);
            if (sp != null)
            {
                sp.soluong = int.Parse(cls["Soluong"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult XoaTatCaGioHang()
        {
            List<Giohang> lgiohang = Laygiohang();
            lgiohang.Clear();
            return RedirectToAction("GioHang");
        }

        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
                return RedirectToAction("Dangnhap", "User");
            if (Session["Giohang"] == null)
                return RedirectToAction("Index", "Product");
            List<Giohang> lstGioHang = Laygiohang();
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            ViewBag.Tongsoluongsanpham = Tongsoluongsanpham();
            return View(lstGioHang);
        }
        public ActionResult DatHang(FormCollection collection)
        {
            Donhang dh = new Donhang();
            Khachhang kh = (Khachhang)Session["TaiKhoan"];
            Product pd = new Product();

            List<Giohang> gh = Laygiohang();
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);

            dh.Idkhach = kh.Idkhach;
            dh.ngaydat = DateTime.Now;
            dh.ngaygiao = DateTime.Parse(ngaygiao);

            data.Donhangs.Add(dh);
            data.SaveChanges();
            foreach (var ele in gh)
            {
                CTHD ctdh = new CTHD();
                ctdh.Iddonhang = dh.Iddonhang;
                ctdh.soluong = ele.soluong;
                ctdh.gia = ele.gia;
                pd = data.Products.Single(p => p.Idproduct == ele.Id);
                ctdh.Idproduct = ele.Id;
                data.SaveChanges();
                data.Ctdhs.Add(ctdh);
            }
            data.SaveChanges();
            Session["Giohang"] = null;
            return RedirectToAction("Index", "Product");
        }
    }
}