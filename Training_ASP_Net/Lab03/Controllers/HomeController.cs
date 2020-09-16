using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        private BabyShopEntities db = new BabyShopEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowInfo()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult NewProducts()
        {
            List<Product> products = db.Products.Where(p => p.IsDelete == false && p.IsActive == true).OrderByDescending(p => p.CreatedAt).Take(8).ToList<Product>();
            return PartialView(products);
        }

        [ChildActionOnly]
        public ActionResult HotProducts()
        {
            List<Product> products = db.Products.Where(p => p.IsDelete == false && p.IsActive == true).OrderByDescending(p => p.Viewes).Take(8).ToList<Product>();
            return PartialView(products);
        }

        [ChildActionOnly]
        public ActionResult BestSeller()
        {
            List<Product> products = db.Products.Where(p => p.IsDelete == false && p.IsActive == true).OrderByDescending(p => p.Sales).Take(8).ToList<Product>();
            return PartialView(products);
        }

    }
}