using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceApp.ViewModels
{
    public class RegisterForCustomersViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter customer name.")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please enter Your Information.")]
        public string FirstPart { get; set; }

        [Required(ErrorMessage = "Please enter Your Information.")]
        public string SecondPart { get; set; }
        [Required(ErrorMessage = "Please enter Your Number.")]
        [Display(Name = "NRC No : ")]
        public string NRCnumber { get; set; }
        [Required(ErrorMessage = "Please enter Your phone number.")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Please enter Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please select city.")]
        public string CityName { get; set; }
        public Guid CityId { get; set; }
        [Required(ErrorMessage = "Please select Township.")]
        public string TownshipName { get; set; }
        public Guid TownshipId { get; set; }
        [Required(ErrorMessage = "Please enter your address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter date of birth.")]
        [Display(Name = "Date Of Birth : ")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please select gender.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please select Photo.")]
        public string photo { get; set; }
        public List<RegisterForCustomersViewModel> RegCustomers = new List<RegisterForCustomersViewModel>();
        public List<CityViewModel> Cities = new List<CityViewModel>();
        public List<TownshipsViewModel> Townships = new List<TownshipsViewModel>();
        public List<SelectListItem> FirstParts = new List<SelectListItem>();
        public List<SelectListItem> SecondParts = new List<SelectListItem>();
    }
}