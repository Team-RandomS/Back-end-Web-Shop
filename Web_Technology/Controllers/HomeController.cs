using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Technology.Models;

namespace Web_Technology.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            var all_product = from s in db.Products select s;
            return View(all_product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            var E_sach = db.Products.First(m => m.Idproduct == id);
            return View(E_sach);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_product = db.Products.First(m => m.Idproduct == id);
            var E_name = collection["Productname"];
            var E_price = Convert.ToDouble(collection["gia"]);
            var E_image = collection["Imagepicture"];
            E_product.Idproduct = id;
            if(string.IsNullOrEmpty(E_name))
            {
                ViewData["Error"] = "Don't empty!";
            }    
            else
            {
                E_product.Productname = E_name.ToString();
                E_product.gia = E_price;
                E_product.Imagepicture = E_image.ToString();
                UpdateModel(E_product);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return this.Edit(id);

        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}