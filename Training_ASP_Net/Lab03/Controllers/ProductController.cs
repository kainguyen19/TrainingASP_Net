using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab3.Models;
using Lab3.ViewModels;

namespace Lab3.Controllers
{
    public class ProductController : Controller
    {
        private BabyShopEntities db = new BabyShopEntities();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = db.Products.Where(p => p.IsDelete == false).ToList<Product>();
            return View(products);
        }
        public ActionResult setActive(int id)
        {
            Product product = db.Products.Single(p => p.ID == id);
            product.IsActive = !product.IsActive;

            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult delete(int id)
        {
            Product product = db.Products.Single(p => p.ID == id);
            product.IsDelete = true;

            db.SaveChanges();

            return RedirectToAction("index");
        }

        // GET: /product/create
        public ActionResult create()
        {
            List<Category> categories = db.Categories.Where(c => c.IsDelete == false).ToList<Category>();
            ViewBag.categories = categories;

            List<Brand> brands = db.Brands.Where(b => b.IsDelete == false).ToList<Brand>();
            ViewBag.brands = brands;

            List<Age> ages = db.Ages.Where(a => a.IsDelete == false).ToList<Age>();
            ViewBag.ages = ages;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(ProductsViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();

                product.Name = productViewModel.Name;
                product.Price = productViewModel.Price;
                product.Detail = productViewModel.Detail;
                product.CategoryID = productViewModel.CategoryID;
                product.BrandID = productViewModel.BrandID;
                product.AgeID = productViewModel.AgeID;

                //product.ThumbnailURL = productViewModel.ThumbnailURL;

                product.IsActive = true;
                product.IsDelete = false;
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;

                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("index");
            }
            else
            {
                return View(ModelState);
            }

        }
    }
}