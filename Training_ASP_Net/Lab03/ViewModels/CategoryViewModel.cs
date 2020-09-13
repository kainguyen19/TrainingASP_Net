using Lab3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace Lab3.ViewModels
{
    public class CategoryViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Category name is not blank")]
        public string Name { get; set; }

        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}