using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Technology.Models;
using Web_Technology.ViewModel;

namespace Web_Technology.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            var all_product = from s in db.Products select s;
            return View(all_product);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult DetailAdmin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            var viewmodel = new ProductViewModel
            {
                Categories = db.Categories.ToList()
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = db.Categories.ToList();
                return View("Create", viewModel);
            }
            var product = new Product
            {
                Productname = viewModel.Productname,
                gia = viewModel.gia,
                Imagepicture = viewModel.Imagepicture,
                Idgory = viewModel.Idgory
            };
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        
    }
}