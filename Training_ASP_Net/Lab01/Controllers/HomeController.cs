using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductWithID(int id)
        {
            ViewBag.data = "Product ID = " + id.ToString();
            return View();
        }

        public ActionResult GetProductWithName(string keyword)
        {
            ViewBag.data = "Product Name = " + keyword;
            return View();
        }

        public ActionResult Search(string keyword_1, string keyword_2)
        {
            ViewBag.data = "Keyword: " + keyword_1 + " - " + keyword_2;
            return View();
        }

        
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string us, string pw)
        {
            ViewBag.data = "Username: " + us + " - Password: " + pw;
            return View("LoginSuccess");
        }
    }
}