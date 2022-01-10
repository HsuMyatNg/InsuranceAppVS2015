using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models
{
    public class ReportModel
    {
        public Guid Id { get; set; }
        public Guid RegistrationId { get; set; }
        public Guid PolicyId { get; set; }
        public Guid CustPolicyId { get; set; }
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter date.")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public bool IsDeleted { get; set; }
        public long Version { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}