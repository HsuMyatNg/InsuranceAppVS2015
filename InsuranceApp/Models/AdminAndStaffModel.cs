using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models
{
    public class AdminAndStaffModel
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

       
        [Required(ErrorMessage = "Please enter NRC.")]
        [Display(Name = "NRC No : ")]
        public string NRC { get; set; }


        [Required(ErrorMessage = "Please enter Your Information.")]
        public string FirstPart { get; set; }

        [Required(ErrorMessage = "Please enter Your Information.")]
        public string SecondPart { get; set; }
        [Required(ErrorMessage = "Please enter Your Number.")]
        [Display(Name = "NRC No : ")]
        public string NRCnumber { get; set; }

        [Required(ErrorMessage = "Please enter date of birth.")]
        [Display(Name = "Date Of Birth : ")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public bool IsDeleted { get; set; }
        public long Version { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}