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

        public CartViewModel()
        {
            this.carts = new List<CartItemViewModel>();
        }

        public void Add(Product p)
        {
            if (this.carts.Count == 0)
            {
                CartItemViewModel cart = new CartItemViewModel(p);
                this.carts.Add(cart);
            }
            else
            {
                foreach (CartItemViewModel c in this.carts)
                {
                    if (c.product.ID == p.ID)
                    {
                        c.quantity++;
                        return;
                    }
                }

                // add new product to cart
                CartItemViewModel cart = new CartItemViewModel(p);
                this.carts.Add(cart);
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
                    cart.quantity = quantity;
            }
        }

        public void Remove(int productID)
        {
            foreach(CartItemViewModel cart in this.carts)
            {
                if(cart.product.ID == productID)
                {
                    this.carts.Remove(cart);
                    return;
                }
            }
        }
    }
}