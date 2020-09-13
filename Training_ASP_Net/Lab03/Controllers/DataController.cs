using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class DataController : Controller
    {
        private BabyShopEntities db = new BabyShopEntities();

        // GET: Data
        public ActionResult Index()
        {
            List<Product> lstProduct = db.Products.ToList<Product>();
            return View(lstProduct);
        }
    }
}