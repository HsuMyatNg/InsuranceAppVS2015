using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.ViewModels
{
    public class PolicyViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter policy name.")]
        public string Policy { get; set; }
        [Required(ErrorMessage = "Enter policy type.")]
        public Guid CategoryId { get; set; }
        public string PolicyType { get; set; }
        [Required(ErrorMessage = "Enter duration.")]
        public string Duration { get; set; }
        [Required(ErrorMessage = "Enter cost.")]
        public double Cost { get; set; }
        public string Description { get; set; }
        public List<CategoryViewModel> Catagories = new List<CategoryViewModel>();
        public List<PolicyViewModel> Policies = new List<PolicyViewModel>();
    }
}