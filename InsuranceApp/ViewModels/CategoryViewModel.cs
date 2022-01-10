using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter category name.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Choose Photo.")]
        public string Photo { get; set; }
        public string Description { get; set; }
    }
}