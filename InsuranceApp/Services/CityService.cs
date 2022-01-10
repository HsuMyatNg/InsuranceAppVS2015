using InsuranceApp.Models;
using InsuranceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Services
{
    public class CityService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public List<CityViewModel> GetCities()
        {
            List<CityViewModel> cities = _context.Cities
                .Where(c => !c.IsDeleted)
                .Select(c => new CityViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
            return cities;
        }
        public CityViewModel GetCityWithId(Guid id)
        {
            CityViewModel viewModel = GetCities()
                 .Where(c => c.Id == id)
                 .FirstOrDefault();
            return viewModel;
        }
        public void Create(CityViewModel viewModel)
        {
            var now = DateTime.Now;
            CityModel entity = new CityModel
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                IsDeleted = false,
                Version = 1,
                CreatedUserId = viewModel.CurrentUserId,
                CreatedDate = now,
                UpdatedDate = now,
                UpdatedUserId = viewModel.CurrentUserId
            };
            _context.Cities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(CityViewModel viewModel)
        {
            var now = DateTime.Now;

            CityModel entity = _context.Cities
                .Where(c => c.Id == viewModel.Id)
                .FirstOrDefault();

            if (entity != null)
            {
                entity.Name = viewModel.Name;
                entity.Version++;
                entity.UpdatedDate = now;
                entity.UpdatedUserId = viewModel.CurrentUserId;
                _context.SaveChanges();
            }

        }
        public void Delete(Guid id, string currentUserId)
        {
            var now = DateTime.Now;

            CityModel entity = _context.Cities
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.UpdatedDate = now;
                entity.UpdatedUserId = currentUserId;
                _context.SaveChanges();
            }


        }

    }
}