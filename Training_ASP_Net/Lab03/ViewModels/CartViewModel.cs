using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.ViewModels
{
    [Serializable]
    public class CartViewModel
    {
        public List<CartItemViewModel> carts { get; set; }
        public int totalPrice { get; set; }

        public CartViewModel()
        {
            this.carts = new List<CartItemViewModel>();
            this.totalPrice = 0;
        }

        public void Add(Product p)
        {
            if (this.carts.Count == 0)
            {
                CartItemViewModel cart = new CartItemViewModel(p);
                this.carts.Add(cart);
                this.totalPrice += (int)p.Price;
            }
            else
            {
                foreach (CartItemViewModel c in this.carts)
                {
                    if (c.product.ID == p.ID)
                    {
                        c.quantity++;
                        this.totalPrice += (int)p.Price;
                        return;
                    }
                }

                // add new product to cart
                CartItemViewModel cart = new CartItemViewModel(p);
                this.carts.Add(cart);
                this.totalPrice += (int)p.Price;
            }
        }

        public void Update(int productID, int quantity)
        {
            if (quantity < 0)
                return;
            if (quantity == 0)
            {
                Remove(productID);
                return;
            }

            foreach(CartItemViewModel cart in this.carts)
            {
                if (cart.product.ID == productID)
                {
                    this.totalPrice -= ((int)cart.product.Price * cart.quantity);
                    cart.quantity = quantity;
                    this.totalPrice += ((int)cart.product.Price * cart.quantity);
                    return;
                }
            }
        }

        public void Remove(int productID)
        {
            foreach(CartItemViewModel cart in this.carts)
            {
                if(cart.product.ID == productID)
                {
                    this.carts.Remove(cart);
                    this.totalPrice -= ((int)cart.product.Price * cart.quantity);
                    return;
                }
            }
        }
    }
}