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
    public class CityController : Controller
    {
        // GET: City
        private readonly CityService _cityService = new CityService();
        // GET: City
        public ActionResult Index()
        {
            List<CityViewModel> cities = _cityService.GetCities();
            return View(cities);
        }
        public ActionResult Create()
        {
            CityViewModel cities = new CityViewModel();
            return View(cities);
        }
        [HttpPost]
        public ActionResult Create(CityViewModel viewModel)
        {
            viewModel.CurrentUserId = User.Identity.GetUserId();
            _cityService.Create(viewModel);
            return View();
        }
        public ActionResult Edit(Guid id)
        {
            CityViewModel model = _cityService.GetCityWithId(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CityViewModel viewModel)
        {
            viewModel.CurrentUserId = User.Identity.GetUserId();
            _cityService.Update(viewModel);
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            string currentUserId = User.Identity.GetUserId();
            _cityService.Delete(id, currentUserId);
            return View();
        }
    }
}