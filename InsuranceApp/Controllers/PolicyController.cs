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
    public class PolicyController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly PolicyService _policyServices = new PolicyService();
        private readonly CategoryService _categoryService = new CategoryService();
        // GET: Policy
        public ActionResult Index()
        {
            List<PolicyViewModel> policies = _policyServices.GetPolicies();
            return View(policies);
        }
        public ActionResult CreatePolicy()
        {
            PolicyViewModel model = new PolicyViewModel();
            model.Policies = _policyServices.GetPoliciesForDropdown();
            model.Catagories = _categoryService.GetCatagories();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreatePolicy(PolicyViewModel viewModel)
        {
           string currentUserId = User.Identity.GetUserId();
            _policyServices.CreatePolicy(viewModel, currentUserId);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditPolicy(Guid id)
        {
            PolicyViewModel model = _policyServices.GetPoliciesById(id);
            if(model!=null)
            {
                ViewBag.Description = model.Description;
                model.Policies = _policyServices.GetPoliciesForDropdown();
                model.Catagories = _categoryService.GetCatagories();
                return View(model);
            }
           
            return View();
        }
        [HttpPost]
        public ActionResult EditPolicy(PolicyViewModel viewModel)
        {
            string currentUserId = User.Identity.GetUserId();
            _policyServices.EditPolicy(viewModel, currentUserId);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid id)
        {
            string currentUserId = User.Identity.GetUserId();
            _policyServices.Delete(id, currentUserId);
            return RedirectToAction("Index");
        }

    }
}