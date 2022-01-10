using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.ViewModels
{
    public class TownshipsViewModel
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string TownshipName { get; set; }
        public List<CityViewModel> Cities { get; set; } = new List<CityViewModel>();

        public string CurrentUserId { get; set; }
    }
}