using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab3.Models;
using Lab3.ViewModels;
using Microsoft.AspNet.Identity;

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
                User user = db.Users.SingleOrDefault(u => u.UserName == userViewModel.UserName && u.Password == hashPassword && u.IsActive == true && u.IsDelete == false);
                
                if(user == null)
                {
                    ViewBag.ErrorMessage = "User name or Password is not exist";
                    
                    return View(userViewModel);
                }
                else
                {
                    Session["user"] = user;

                    if (Session["IsCheckOut"] != null && (Boolean)Session["IsCheckOut"] == true)
                        return RedirectToAction("CheckOut", "ShoppingCart");
                    else
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserViewModel userViewModel)
        {
            if(userViewModel.UserName != null)
            {
                // check username is exist?
                User user = db.Users.SingleOrDefault(u => u.UserName == userViewModel.UserName);
                if (user != null)
                {
                    ViewBag.errorMessage = "User name is taken";
                    return View(userViewModel);
                }
            }

            if (userViewModel.Password != null && userViewModel.DisplayName != null && userViewModel.Telephone != null && userViewModel.Address != null)
            {
                User user = new User();
                
                user.UserName = userViewModel.UserName;
                user.Password = MD5(userViewModel.Password);
                user.DisplayName = userViewModel.DisplayName;
                user.Telephone = userViewModel.Telephone;
                user.Address = userViewModel.Address;
                user.IsActive = true;
                user.IsDelete = false;
                user.CeatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                user.RoleID = 1;

                db.Users.Add(user);
                db.SaveChanges();

                Session["user"] = user;

                return RedirectToAction("Index", "Home");
            }
            else
                return View(userViewModel);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

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