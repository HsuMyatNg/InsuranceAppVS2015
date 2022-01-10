using InsuranceApp.Models;
using InsuranceApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly ReportService _reportsService = new ReportService();
        private readonly CustomersPolicyService _cusPolicy = new CustomersPolicyService();
        private readonly RegisterForCustomersService _regService = new RegisterForCustomersService();
        private readonly PolicyService _policyService = new PolicyService();
        private readonly CategoryService _categoryService = new CategoryService();
        private readonly AdminAndStaffService _adminStaff = new AdminAndStaffService();

        public ActionResult MainPage()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Layout()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Dashboard()
        {
            ViewBag.Reguser = _regService.GetCustomers().Count();
            ViewBag.Policies = _policyService.GetPolicies().Count();
            ViewBag.AdminStaff = _adminStaff.GetAdminAndStaffList().Count();

            GregorianCalendar pc = new GregorianCalendar();
            var thisDate = DateTime.Now;
            ViewBag.dayName = pc.GetDayOfWeek(thisDate);
            var month = pc.GetMonth(thisDate);
            switch (month)
            {

                case 1:
                    ViewBag.Month = "January";
                    break;
                case 2:
                    ViewBag.Month = "February";
                    break;
                case 3:
                    ViewBag.Month = "March";
                    break;
                case 4:
                    ViewBag.Month = "April";
                    break;
                case 5:
                    ViewBag.Month = "May";
                    break;
                case 6:
                    ViewBag.Month = "Jun";
                    break;
                case 7:
                    ViewBag.Month = "July";
                    break;
                case 8:
                    ViewBag.Month = "August";
                    break;
                case 9:
                    ViewBag.Month = "September";
                    break;
                case 10:
                    ViewBag.Month = "October";
                    break;
                case 11:
                    ViewBag.Month = "November";
                    break;
                case 12:
                    ViewBag.Month = "December";
                    break;
            }
            ViewBag.Day = pc.GetDayOfMonth(thisDate);
            ViewBag.Year = pc.GetYear(thisDate);


            var data = _context.CustomersPolicies.Join
               (_context.Policies,
              c => c.PolicyId,
              p => p.Id,
              (c, p) => new { c, p })
              .GroupBy
              (cp => new
              {
                  Id = cp.c.PolicyId,
                  Name = cp.p.Policy
              }).Select(cp => new
              {
                  Id = cp.Key.Id,
                  Name = cp.Key.Name,
                  Count = cp.Count()
              });

            var boy = _context.RegisterUsers.Where(r => r.Gender == "Male").Select(r => r).ToList();
            ViewBag.male = boy.Count();
            var girl = _context.RegisterUsers.Where(r => r.Gender == "Female").Select(r => r).ToList();
            ViewBag.female = girl.Count();
            return View();
        }
        public JsonResult GetCusPolicyNo()
        {
            var data = _context.CustomersPolicies.Join
                 (_context.Policies,
                c => c.PolicyId,
                p => p.Id,
                (c, p) => new { c, p })
                .GroupBy
                (cp => new
                {
                    Id = cp.c.PolicyId,
                    Name = cp.p.Policy
                }).Select(cp => new
                {
                    Id = cp.Key.Id,
                    Name = cp.Key.Name,
                    Count = cp.Count()
                });

            
            List<object> iData = new List<object>();
            DataTable dt = new DataTable();
            dt.Columns.Add("Policies", System.Type.GetType("System.String"));
            dt.Columns.Add("Users", System.Type.GetType("System.Int32"));

            DataRow dr = dt.NewRow();
            foreach (var item in data)
            {
                dr["Policies"] = item.Name;
                dr["Users"] = item.Count;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

      
    }
}