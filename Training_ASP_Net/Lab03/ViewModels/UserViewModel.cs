using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3.ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "User name is not blank")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is not blank")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Display name is not blank")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Telephone number is not blank")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Address is not blank")]
        public string Address { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CeatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> RoleID { get; set; }
    }
}