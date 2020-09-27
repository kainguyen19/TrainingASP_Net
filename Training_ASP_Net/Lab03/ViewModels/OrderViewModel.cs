using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3.ViewModels
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public Nullable<int> TotalPrice { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> OrderStatusID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> SellerID { get; set; }

        [Required(ErrorMessage = "Shipping name is not blank")]
        public string ShippingName { get; set; }

        [Required(ErrorMessage = "Shipping telephone number is not blank")]
        public string ShippingTel { get; set; }

        [Required(ErrorMessage = "Shipping address is not blank")]
        public string ShippingAddress { get; set; }
    }
}