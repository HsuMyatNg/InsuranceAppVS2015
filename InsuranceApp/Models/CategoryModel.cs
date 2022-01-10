using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Enter category name.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Choose Photo.")]
        public string Photo { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public long Version { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

 }