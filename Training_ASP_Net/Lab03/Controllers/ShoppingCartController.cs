using Lab3.Models;
using Lab3.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
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

        public ActionResult CheckOut()
        {
            if (Session["user"] == null)
            {
                Session["IsCheckOut"] = true;
                return RedirectToAction("Login", "User");
            }

            User user = (User)Session["user"];
            CartViewModel shoppingCart = (CartViewModel)Session["ShoppingCart"];

            Order order = new Order();
            
            order.UserID = user.ID;
            order.ShippingAddress = user.Address;
            order.ShippingTel = user.Telephone;
            order.ShippingName = user.DisplayName;
            order.TotalPrice = shoppingCart.totalPrice;

            order.OrderStatusID = 1;
            order.CreatedAt = DateTime.Now;
            order.UpdatedAt = DateTime.Now;

            db.Orders.Add(order);
            db.SaveChanges();

            List<Order> lstOrder = db.Orders.Where(o => o.UserID == order.UserID).OrderByDescending(o => o.ID).Take(1).ToList<Order>();

            if (lstOrder.Count > 0)
                order.ID = lstOrder[0].ID;
            else
                return RedirectToAction("Index", "Home");
            
            foreach(CartItemViewModel cart in shoppingCart.carts)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderID = order.ID;
                orderDetail.ProductID = cart.product.ID;
                orderDetail.SalePrice = cart.product.Price;
                orderDetail.Quantity = cart.quantity;

                db.OrderDetails.Add(orderDetail);

                // update sale-count for Product
                Product product = db.Products.Single(p => p.ID == cart.product.ID);
                product.Sales += cart.quantity;

                db.SaveChanges();
            }

            Session.Remove("ShoppingCart");

            ViewBag.OrderID = order.ID;
            return View();
        }
    }
}