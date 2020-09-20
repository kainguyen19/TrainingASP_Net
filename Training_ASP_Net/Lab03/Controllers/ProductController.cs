using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult Detail(int id)
        {
            Product product = db.Products.Single(p => p.ID == id);
            
            product.Viewes++;
            db.SaveChanges();

            return View(product);
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
        public ActionResult create(ProductViewModel productViewModel, HttpPostedFileBase _file)
        {
            if (ModelState.IsValid)
            {
                string _FileName = "";

                // proccess upload file
                if(_file.ContentLength > 0)
                {
                    // get file name
                    _FileName = Path.GetFileName(_file.FileName);

                    // save file to the path in project
                    string _path = Path.Combine(Server.MapPath("/Content/img/products"), _FileName);
                    
                    // proccess save file
                    _file.SaveAs(_path);
                }

                Product product = new Product();

                product.Name = productViewModel.Name;
                product.Price = productViewModel.Price;
                product.Detail = productViewModel.Detail;
                product.CategoryID = productViewModel.CategoryID;
                product.BrandID = productViewModel.BrandID;
                product.AgeID = productViewModel.AgeID;
                product.ThumbnailURL = _FileName;

                product.IsActive = true;
                product.IsDelete = false;
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;

                product.Viewes = 0;
                product.Sales = 0;

                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("index");
            }
            else
            {
                return View(ModelState);
            }
        }

        public ActionResult edit(int id)
        {
            Product product = db.Products.Single(p => p.ID == id);
            
            ProductViewModel productViewModel = new ProductViewModel();
            
            productViewModel.ID = product.ID;
            productViewModel.Name = product.Name;
            productViewModel.Detail = product.Detail;
            productViewModel.Price = product.Price;
            productViewModel.CategoryID = product.CategoryID;
            productViewModel.BrandID = product.BrandID;
            productViewModel.AgeID = product.AgeID;
            productViewModel.ThumbnailURL = product.ThumbnailURL;
            productViewModel.ImageURL = product.ImageURL;

            List<Category> categories = db.Categories.Where(c => c.IsDelete == false).ToList<Category>();
            ViewBag.categories = categories;

            List<Brand> brands = db.Brands.Where(b => b.IsDelete == false).ToList<Brand>();
            ViewBag.brands = brands;

            List<Age> ages = db.Ages.Where(a => a.IsDelete == false).ToList<Age>();
            ViewBag.ages = ages;

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit(ProductViewModel productViewModel, HttpPostedFileBase _file)
        {
            if (ModelState.IsValid)
            {
                string _FileName = "";

                // proccess upload file
                if (_file.ContentLength > 0)
                {
                    // get file name
                    _FileName = Path.GetFileName(_file.FileName);

                    // save file to the path in project
                    string _path = Path.Combine(Server.MapPath("/Content/img/products"), _FileName);

                    // proccess save file
                    _file.SaveAs(_path);
                }

                Product product = db.Products.Single(p => p.ID == productViewModel.ID);

                product.Name = productViewModel.Name;
                product.Price = productViewModel.Price;
                product.Detail = productViewModel.Detail;
                product.CategoryID = productViewModel.CategoryID;
                product.BrandID = productViewModel.BrandID;
                product.AgeID = productViewModel.AgeID;
                
                if(_file!= null && _file.ContentLength > 0)
                    product.ThumbnailURL = _FileName;

                product.IsActive = true;
                product.IsDelete = false;
                product.UpdatedAt = DateTime.Now;

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