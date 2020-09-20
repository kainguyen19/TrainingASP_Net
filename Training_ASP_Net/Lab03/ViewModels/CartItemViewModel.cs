using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.ViewModels
{
    [Serializable]
    public class CartItemViewModel
    {
        public Product product { get; set; }
        public int quantity { get; set; }

        public CartItemViewModel()
        {
            this.quantity = 0;
        }

        public CartItemViewModel(Product p)
        {
            this.product = p;
            this.quantity = 1;
        }
    }
}