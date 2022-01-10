using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.ViewModels
{
    public class CityViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CurrentUserId { get; set; }
    }
}