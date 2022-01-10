using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models
{
    public class CityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public long Version { get; set; }

        public string CreatedUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedUserId { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}