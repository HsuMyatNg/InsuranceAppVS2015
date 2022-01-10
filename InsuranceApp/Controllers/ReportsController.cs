using InsuranceApp.Models;
using InsuranceApp.Services;
using InsuranceApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceApp.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class ReportsController : Controller
    {
        public ActionResult AdminStaffReport()
        {
            AdminAndStaffService adminstaffService = new AdminAndStaffService();
            List<AdminAndStaffViewModel> data = adminstaffService.GetAdminAndStaffList();
            Session["ReportData"] = data;
            return View();
        }

        public ActionResult CategoryReport()
        {
            CategoryService categoryService = new CategoryService();
            List<CategoryViewModel> data = categoryService.GetCatagories();
            Session["ReportData"] = data;
            return View();
        }
        public ActionResult CustomersPolicyReport()
        {
            CustomersPolicyService cusPolicy = new CustomersPolicyService();
            List<CustomersPolicyViewModel> data = cusPolicy.GetCustomersPolicy();
            Session["ReportData"] = data;
            return View();
        }
        public ActionResult RegisterForCustomerReport()
        {
            RegisterForCustomersService regCus = new RegisterForCustomersService();
            List<RegisterForCustomersViewModel> data = regCus.GetCustomers();
            //foreach (var item in data)
            //{
            //    item.photo="<img src="+"item.photo"+">";
            //}

            Session["ReportData"] = data;
            return View();
        }
        public ActionResult PolicyReport()
        {
            PolicyService policyService = new PolicyService();
            List<PolicyViewModel> data = policyService.GetPolicies();
            Session["ReportData"] = data;
            return View();
        }
    }
}