using InsuranceApp.ViewModels;
using InsuranceApp.Services;
using InsuranceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceApp.Controllers
{
    public class TownshipsController : Controller
    {
        // GET: Townships
        private readonly TownshipService _townshipService = new TownshipService();
        public JsonResult GetTownshipsByCityId(Guid cityId)
        {
            List<TownshipsViewModel> townships = _townshipService.GetTownshipsByCityId(cityId);
            return Json(townships, JsonRequestBehavior.AllowGet);
        }
    }
}