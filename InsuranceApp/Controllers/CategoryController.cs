using InsuranceApp.Models;
using InsuranceApp.Services;
using InsuranceApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceApp.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly CategoryService _categoryService = new CategoryService();
        // GET: Category
        public ActionResult Index()
        {
            List<CategoryViewModel> model = _categoryService.GetCatagories();
            return View(model);
        }
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(CategoryViewModel viewModel,HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string imgPath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(imgPath);
            }
            string Img = "~/Images/" + file.FileName;
            string currentUserId = User.Identity.GetUserId();
            _categoryService.CreateCatagories(viewModel,Img,currentUserId);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Guid id)
        {
            string currentUserId = User.Identity.GetUserId();
            CategoryViewModel model = _categoryService.GetCatagoriesById(id);
            
            if (model != null)
            {
                ViewBag.Description = model.Description;
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel viewModel, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string imgPath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(imgPath);
            }
            string Img = "~/Images/" + file.FileName;
            string currentUserId = User.Identity.GetUserId();
            _categoryService.Edit(viewModel,Img, currentUserId);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(Guid id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}