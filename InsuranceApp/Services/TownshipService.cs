using InsuranceApp.Models;
using InsuranceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Services
{
    public class TownshipService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public List<TownshipsViewModel> GetTownships()
        {
            List<TownshipsViewModel> townships = _context.Townships.
                Select(t => new TownshipsViewModel
                {
                    Id = t.Id,
                    /*CityId=t.CityId,*/
                    TownshipName = t.TownshipName
                }).ToList();
            return townships;
        }
        public List<TownshipsViewModel> GetTownshipsByCityId(Guid cityId)
        {
            List<TownshipsViewModel> townships = _context.Townships
                .Where(t => t.CityId == cityId)
                .Select(t => new TownshipsViewModel
                {
                    Id = t.Id,
                    TownshipName = t.TownshipName
                })
            .ToList();
            return townships;
        }
    }
}