using InsuranceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models
{
    public class RegisterForCustomersModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter customer name.")]
        public string CustomerName { get; set; }
        [Display(Name = "NRC No : ")]
        public string NRC { get; set; }


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
        public Guid CityId { get; set; }
        [Required(ErrorMessage = "Please select Township.")]
        public Guid TownshipId { get; set; }
        [Required(ErrorMessage = "Please enter your address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter date of birth.")]
        [Display(Name = "Date Of Birth : ")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please select gender.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please select Photo.")]
        public string photo { get; set; }
        public bool IsDeleted { get; set; }
        public long Version { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}