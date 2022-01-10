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
    public class RegisterForCustomersController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly RegisterForCustomersService _customerService = new RegisterForCustomersService();
        private readonly CityService _cityService = new CityService();
        private readonly TownshipService _townShipService = new TownshipService();
        // GET: RegisterForCustomers
        #region NRC
        List<SelectListItem> _firstParts = new List<SelectListItem>
            {
                new SelectListItem {Value="1",Text="1" },
                new SelectListItem {Value="2",Text="2" },
                new SelectListItem {Value="3",Text="3" },
                new SelectListItem {Value="4",Text="4" },
                new SelectListItem {Value="5",Text="5" },
                new SelectListItem {Value="6",Text="6" },
                new SelectListItem {Value="7",Text="7" },
                new SelectListItem {Value="8",Text="8" },
                new SelectListItem {Value="9",Text="9t" },
                new SelectListItem {Value="10",Text="10" },
                new SelectListItem {Value="11",Text="11" },
                new SelectListItem {Value="12",Text="12" }
            };
        List<SelectListItem> _secondParts = new List<SelectListItem>
            {

                new SelectListItem {Value="A La Na",Text="2" },
                new SelectListItem {Value="A SA NA",Text="3" },
                new SelectListItem {Value="BA HA NA",Text="4" },
                new SelectListItem {Value="DA TA HTA",Text="5" },
                new SelectListItem {Value="DA GA HSA",Text="6" },
                new SelectListItem {Value="DA GA NA",Text="7" },
                new SelectListItem {Value="DA GA RA",Text="8" },
                new SelectListItem {Value="DA HGA TA",Text="9t" },
                new SelectListItem {Value="DA LA NA",Text="10" },
                new SelectListItem {Value="DA PA NA",Text="11" },
                new SelectListItem {Value="HTA TA PA",Text="12" },
                 new SelectListItem {Value="KA KA KA",Text="2" },
                new SelectListItem {Value="KA KHA KA",Text="3" },
                new SelectListItem {Value="KA MA NA",Text="4" },
                new SelectListItem {Value="KA MA RA",Text="5" },
                new SelectListItem {Value="KA MA TA",Text="6" },
                new SelectListItem {Value="KA TA NA",Text="7" },
                new SelectListItem {Value="KA TA TA",Text="8" },
                new SelectListItem {Value="KHA RA NA",Text="9t" },
                new SelectListItem {Value="LA KA NA",Text="10" },
                new SelectListItem {Value="LA MA TA",Text="11" },
                new SelectListItem {Value="LA THA YA",Text="12" },
                new SelectListItem {Value="MA BHA NA",Text="2" },
                new SelectListItem {Value="MA GA DA",Text="3" },
                new SelectListItem {Value="MA GA TA",Text="4" },
                new SelectListItem {Value="MA RA KA",Text="5" },
                new SelectListItem {Value="PA BHA TA",Text="6" },
                new SelectListItem {Value="PA ZA TA",Text="7" },
                new SelectListItem {Value="RA KA NA",Text="8" },
                new SelectListItem {Value="RA KA THA",Text="9t" },
                new SelectListItem {Value="SA KHA NA",Text="10" },
                new SelectListItem {Value="TA KA NA",Text="11" },
                new SelectListItem {Value="TA TA HTA",Text="12" },
                new SelectListItem {Value="TA TA NA",Text="4" },
                new SelectListItem {Value="THA KA TA",Text="5" },
                new SelectListItem {Value="THA KHA NA",Text="6" },
                new SelectListItem {Value="THA LA NA",Text="7" },
                new SelectListItem {Value="U KA MA",Text="8" },
                new SelectListItem {Value="U Ka Ta",Text="U Ka Ta" },
            };
        #endregion
        public ActionResult Index()
        {
            List<RegisterForCustomersViewModel> model = _customerService.GetCustomers();
            return View(model);
        }
        public ActionResult CreateCustomers()
        {
            RegisterForCustomersViewModel model = new RegisterForCustomersViewModel();
            model.RegCustomers = _customerService.GetRegCustomersForDropdown();
            model.Cities = _cityService.GetCities();
           
            model.FirstParts = _firstParts;
            model.SecondParts = _secondParts;
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateCustomers(RegisterForCustomersViewModel viewModel, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string imgPath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(imgPath);
            }
            string Img = "~/Images/" + file.FileName;
            string currentUserId = User.Identity.GetUserId();
            _customerService.CreateCustomers(viewModel,Img, currentUserId);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Guid id)
        {
            
            RegisterForCustomersViewModel model = _customerService.GetCustomerById(id);
            ViewBag.Address = model.Address;
                model.RegCustomers = _customerService.GetRegCustomersForDropdown();
                model.Cities = _cityService.GetCities();
                model.Townships = _townShipService.GetTownships();
                model.FirstParts = _firstParts;
                model.SecondParts = _secondParts;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(RegisterForCustomersViewModel viewModel,HttpPostedFileBase file)
        {
            string currentUserId = User.Identity.GetUserId();
            
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string imgPath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(imgPath);
            }
            string img = "~/Images/" + file.FileName;
            _customerService.Edit(viewModel,img, currentUserId);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid id)
        {
            _customerService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult DetailUser(Guid id)
        {

            RegisterForCustomersViewModel model = _customerService.GetCustomerById(id);
            model.RegCustomers = _customerService.GetRegCustomersForDropdown();
            model.Cities = _cityService.GetCities();
            // model.Townships = _townShipService.GetTownships();
            model.FirstParts = _firstParts;
            model.SecondParts = _secondParts;
            return View(model);
        }
    }
}