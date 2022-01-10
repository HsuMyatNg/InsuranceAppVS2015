using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models
{
    public class PolicyModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Enter policy name.")]
        public string Policy { get; set; }
        [Required(ErrorMessage = "Enter policy type.")]
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "Enter duration.")]
        public string Duration { get; set; }
        [Required(ErrorMessage = "Enter cost.")]
        public double Cost { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public long Version { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}