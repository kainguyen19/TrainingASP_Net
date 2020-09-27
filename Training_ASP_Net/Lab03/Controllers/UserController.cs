using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Lab3.Models;
using Lab3.ViewModels;

namespace Lab3.Controllers
{
    public class UserController : Controller
    {
        private BabyShopEntities db = new BabyShopEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel userViewModel)
        {
            if (userViewModel.UserName != null && userViewModel.Password != null)
            {
                String hashPassword = MD5(userViewModel.Password);
                User user = db.Users.SingleOrDefault(u => u.UserName == userViewModel.UserName && u.Password == hashPassword);
                
                if(user == null)
                {
                    ViewBag.ErrorMessage = "User name or Password is not exist";
                    return View(userViewModel);
                }
                else
                {
                    Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(userViewModel);
            }
        }

        public ActionResult SignUp()
        {
            return View()
;       }

        public static string MD5(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}