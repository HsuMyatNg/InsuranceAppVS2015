using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.ViewModels
{
    public class CustomersPolicyViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please Select Customer Name.")]
        [Display(Name = "Customer Name ")]
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please Select Customer NRC.")]
        [Display(Name = "Customer NRC ")]
        public string NRCnumber { get; set; }
        [Required(ErrorMessage = "Please select Policy ")]
        [Display(Name = "Policy Name ")]
        public Guid PolicyId { get; set; }
        public string PolicyName { get; set; }
        [Required(ErrorMessage = "Please enter Payment ")]
        [Display(Name = "Payment  ")]
        public double Payment { get; set; }
        [Required(ErrorMessage = "Please enter total installment ")]
        [Display(Name = "Total Installment  ")]
        public double TotalInstallment { get; set; }
        [Required(ErrorMessage = "Please enter date of birth.")]
        [Display(Name = "Start Date  ")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Please enter date of birth.")]
        [Display(Name = "End Date ")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Please enter Norminee ")]
        [Display(Name = "Norminee  ")]
        public string Norminee { get; set; }
        [Required(ErrorMessage = "Please enter how to related ")]
        [Display(Name = "How to related  ")]
        public string Related { get; set; }
        public string Description { get; set; }

        public List<CustomersPolicyViewModel> CustPolicies = new List<CustomersPolicyViewModel>();
        public List<PolicyViewModel> Policies = new List<PolicyViewModel>();
        public List<RegisterForCustomersViewModel> RegCustomers = new List<RegisterForCustomersViewModel>();
    }
}