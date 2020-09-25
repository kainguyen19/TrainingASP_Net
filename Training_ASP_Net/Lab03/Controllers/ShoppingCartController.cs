using Lab3.Models;
using Lab3.ViewModels;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class ShoppingCartController : Controller
    {
        private BabyShopEntities db = new BabyShopEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            CartViewModel shoppingCart = new CartViewModel();

            if (Session["ShoppingCart"] != null)
            {
                shoppingCart = (CartViewModel)Session["ShoppingCart"];
            }

            int totalPrice = 0; 
            foreach(CartItemViewModel cart in shoppingCart.carts)
            {
                totalPrice += (int)cart.product.Price * cart.quantity;
            }

            ViewBag.TotalPrice = totalPrice;

            return View(shoppingCart);
        }

        public ActionResult Add(int id)
        {
            CartViewModel shoppingCart = new CartViewModel();
            
            if(Session["ShoppingCart"] != null)
            {
                shoppingCart = (CartViewModel)Session["ShoppingCart"];
            }

            Product product = db.Products.Single(p => p.ID == id);
            shoppingCart.Add(product);

            Session["ShoppingCart"] = shoppingCart;

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            CartViewModel shoppingCart = new CartViewModel();

            if (Session["ShoppingCart"] != null)
            {
                shoppingCart = (CartViewModel)Session["ShoppingCart"];
            }

            shoppingCart.Remove(id);
            Session["ShoppingCart"] = shoppingCart;

            return RedirectToAction("Index");
        }

        public ActionResult Update(int id, int quantity)
        {
            CartViewModel shoppingCart = new CartViewModel();

            if (Session["ShoppingCart"] != null)
            {
                shoppingCart = (CartViewModel)Session["ShoppingCart"];
            }

            shoppingCart.Update(id, quantity);      
            Session["ShoppingCart"] = shoppingCart;
            
            return RedirectToAction("Index");
        }

    }
}