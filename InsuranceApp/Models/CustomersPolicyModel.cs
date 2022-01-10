using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models
{
    public class CustomersPolicyModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please Select Customer Name.")]
        [Display(Name = "Customer Name: ")]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage ="Please select Policy ")]
        [Display(Name = "Policy Name: ")]
        public Guid PolicyId { get; set; }
        [Required(ErrorMessage = "Please enter Payment ")]
        [Display(Name = "Payment : ")]
        public double Payment { get; set; }
        [Required(ErrorMessage = "Please enter total installment ")]
        [Display(Name = "Total Installment : ")]
        public double TotalInstallment { get; set; }
        [Required(ErrorMessage = "Please enter start date.")]
        [Display(Name = "Start Date : ")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Please enter end date.")]
        [Display(Name = "End Date ")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Please enter Norminee ")]
        [Display(Name = "Norminee : ")]
        public string Norminee { get; set; }
        [Required(ErrorMessage = "Please enter how to related ")]
        [Display(Name = "How to related : ")]
        public string Related { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public long Version { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}