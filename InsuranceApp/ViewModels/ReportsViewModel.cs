using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.ViewModels
{
    public class ReportsViewModel
    {
        public Guid Id { get; set; }
        public Guid RegistrationId { get; set; }
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please Select Customer NRC.")]
        [Display(Name = "Customer NRC ")]
        public string NRCnumber { get; set; }
        public string PhoneNO { get; set; }
        public Guid PolicyId { get; set; }
        [Required(ErrorMessage ="Please enter Policy Name.")]
        public string PolicyName { get; set; }
        public Guid CustPolicyId { get; set; }
        [Required(ErrorMessage = "Please enter total installment ")]
        [Display(Name = "Total Installment : ")]
        public double TotalInstallment { get; set; }
        public Guid CategoryId { get; set; }
        public string InsurancrType { get; set; }
        [Required(ErrorMessage = "Please enter date.")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public List<RegisterForCustomersViewModel> RegCustomers = new List<RegisterForCustomersViewModel>();
        public List<PolicyViewModel> Policies = new List<PolicyViewModel>();
        public List<CustomersPolicyViewModel> CustPolicies = new List<CustomersPolicyViewModel>();
        public List<CategoryViewModel> Categories = new List<CategoryViewModel>();
    }
}