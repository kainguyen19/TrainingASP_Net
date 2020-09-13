using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3.ViewModels
{
    public class ProductsViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is not blank")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is not blank")]
        public Nullable<int> Price { get; set; }
        public string Detail { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public Nullable<int> AgeID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public string ThumbnailURL { get; set; }
        public string ImageURL { get; set; }
    }
}