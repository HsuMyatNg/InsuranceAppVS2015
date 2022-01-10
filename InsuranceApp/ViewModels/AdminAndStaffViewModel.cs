using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceApp.ViewModels
{
    public class AdminAndStaffViewModel
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter Your Name.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please select roll.")]
        public string Roll { get; set; }
        [Required(ErrorMessage = "Please enter Your Phone Number.")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Please enter Your Email.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enrter Password.")]
        [Display(Name = "Enter user Password : ")]

        public string Upwd { get; set; }
        [DataType(DataType.Password)]

        [Required(ErrorMessage = "Please enrter Password.")]
    

        [Display(Name = "Enter Re Password : ")]

        [System.ComponentModel.DataAnnotations.Compare("Upwd")]

        public string Repwd { get; set; }

        [Required(ErrorMessage = "Please enter Your Information.")]
        public string FirstPart { get; set; }

        [Required(ErrorMessage = "Please enter Your Information.")]
        public string SecondPart { get; set; }
        [Required(ErrorMessage = "Please enter Your Number.")]
        [Display(Name = "NRC No : ")]
        public string NRCnumber { get; set; }

        [Required(ErrorMessage = "Please enter date of birth.")]
        [Display(Name = "Date Of Birth : ")]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string CurrentUserId { get; set; }
        public List<SelectListItem> FirstParts = new List<SelectListItem>();
        public List<SelectListItem> SecondParts = new List<SelectListItem>();
        public List<SelectListItem> Rolls = new List<SelectListItem>();
    }
}