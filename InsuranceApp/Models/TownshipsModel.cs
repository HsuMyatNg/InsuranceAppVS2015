using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Models
{
    public class TownshipsModel
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string TownshipName { get; set; }

        public bool IsDeleted { get; set; }

        public long Version { get; set; }

        public string CreatedUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedUserId { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}