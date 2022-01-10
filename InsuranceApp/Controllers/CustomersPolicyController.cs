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
    public class CustomersPolicyController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly CustomersPolicyService _cusPolicy = new CustomersPolicyService();
        private readonly RegisterForCustomersService _regService = new RegisterForCustomersService();
        private readonly PolicyService _policyService = new PolicyService();
        // GET: CustomersPolicy
        public ActionResult Index()
        {
            List<CustomersPolicyViewModel> model = _cusPolicy.GetCustomersPolicy();
            return View(model);
        }
        public ActionResult CreateCustomerPolicy()
        {
            CustomersPolicyViewModel model = new CustomersPolicyViewModel();
            model.RegCustomers = _regService.GetRegCustomersForDropdown();
            model.Policies = _policyService.GetPoliciesForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateCustomerPolicy(CustomersPolicyViewModel viewModel)
        {
            string currentUserId = User.Identity.GetUserId();
            _cusPolicy.CreateCustomersPolicy(viewModel, currentUserId);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Guid id)
        {
            CustomersPolicyViewModel model = _cusPolicy.CreateCustomersPolicyById(id);
            ViewBag.Description = model.Description;
            model.RegCustomers = _regService.GetRegCustomersForDropdown();
                model.Policies = _policyService.GetPoliciesForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CustomersPolicyViewModel viewModel)
        {
            string currentUserId = User.Identity.GetUserId();
            _cusPolicy.Edit(viewModel, currentUserId);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid id)
        {
            _cusPolicy.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult DetailUser(Guid id)
        {
            CustomersPolicyViewModel model = _cusPolicy.CreateCustomersPolicyById(id);
            model.RegCustomers = _regService.GetRegCustomersForDropdown();
            model.Policies = _policyService.GetPoliciesForDropdown();
            return View(model);
        }
    }
}