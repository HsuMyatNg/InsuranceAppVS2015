using InsuranceApp.Models;

using InsuranceApp.Services;
using InsuranceApp.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceApp.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class AdminAndStaffController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly AdminAndStaffService _adminStaffService = new AdminAndStaffService();
        // GET: AdminAndStaff
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
        #region roll
        List<SelectListItem> _Rolls = new List<SelectListItem>
            {
                new SelectListItem {Value="Admin",Text="Admin" },
                new SelectListItem {Value="Staff",Text="Staff" },
               
            };
        #endregion 
        public ActionResult Index()
        {
            var model=_adminStaffService.GetAdminAndStaffList();
            return View(model);
        }
        public ActionResult CreateAdminAndStaff()
        {
            AdminAndStaffViewModel model = new AdminAndStaffViewModel();
            model.FirstParts = _firstParts;
            model.SecondParts = _secondParts;
            model.Rolls = _Rolls;
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateAdminAndStaff(AdminAndStaffViewModel viewModel)
        {

            viewModel.CurrentUserId = User.Identity.GetUserId();
            var model = _context.Users.Where(a => a.Email == viewModel.Email)
                .Select(a => a).FirstOrDefault();
            if (model!= null)
            {
                ViewBag.ErrorMessage = "This mail is already exit..";
                AdminAndStaffViewModel data = new AdminAndStaffViewModel();
                data.FirstParts = _firstParts;
                data.SecondParts = _secondParts;
                data.Rolls = _Rolls;
                return View(data);
            }
            if(model==null)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

                var adminUser = new ApplicationUser() { UserName = viewModel.Email, Email = viewModel.Email };
                string userPassword = viewModel.Upwd;
                var chkUser = userManager.Create(adminUser, userPassword);
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(adminUser.Id, viewModel.Roll);
                }
                _adminStaffService.CreateAdminAndStaff(viewModel);
                
            }
            
            return RedirectToAction("Index");                                                
        }
        public ActionResult EditAdminAndStaff(Guid id)
        {
            AdminAndStaffViewModel model = _adminStaffService.GetDataById(id);
            if(model!=null)
            {
                model.FirstParts = _firstParts;
                model.SecondParts = _secondParts;
               
                model.Rolls = _Rolls;
                model.Repwd = model.Upwd;
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult EditAdminAndStaff(AdminAndStaffViewModel viewModel)
        {
            viewModel.CurrentUserId = User.Identity.GetUserId();
            _adminStaffService.EditAdminAndStaff(viewModel);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdminAndStaff(Guid id)
        {
            _adminStaffService.DeleteAdminAndStaff(id);
            return RedirectToAction("Index");
        }
        public ActionResult DetailUser(Guid id)
        {
            AdminAndStaffViewModel model = _adminStaffService.GetDataById(id);
            if (model != null)
            {
                model.FirstParts = _firstParts;
                model.SecondParts = _secondParts;
                model.Rolls = _Rolls;
                model.Repwd = model.Upwd;
                return View(model);
            }
            return View();
        }
      
    }
}