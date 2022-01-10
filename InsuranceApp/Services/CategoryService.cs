using InsuranceApp.Models;
using InsuranceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public void CreateCatagories(CategoryViewModel viewModel,string img,string currentUserId)
        {
            CategoryModel model = new CategoryModel
            {
                Id = Guid.NewGuid(),
                CategoryName=viewModel.CategoryName,
                Photo=img,
                Description=viewModel.Description,
                IsDeleted = false,
                Version = 1,
                CreatedUserId =currentUserId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UpdatedUserId =currentUserId

            };
            _context.Categories.Add(model);
            _context.SaveChanges();
        }
        public List<CategoryViewModel> GetCatagories()
        {
            List<CategoryViewModel> model = _context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Photo = c.Photo,
                    Description = c.Description
                })
                .ToList();
            return model;
        }
        public CategoryViewModel GetCatagoriesById(Guid id)
        {
            CategoryViewModel model = GetCatagories().Where(c => c.Id == id)
                .Select(c => c).FirstOrDefault();
            return model;
        }
        public void Edit(CategoryViewModel viewModel,string img,string currentUserId)
        {
            CategoryModel entity = _context.Categories
                .Where(c => c.Id == viewModel.Id)
                .Select(c => c).FirstOrDefault();
            if(entity!=null)
            {
                entity.Id = viewModel.Id;
                entity.CategoryName = viewModel.CategoryName;
                entity.Photo = img;
                entity.Description = viewModel.Description;
                entity.Version++;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedUserId = currentUserId;
            }
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            CategoryModel model = _context.Categories
                .Where(c => c.Id == id)
                .Select(c => c).FirstOrDefault();
            if(model!=null)
            {
                _context.Categories.Remove(model);
                _context.SaveChanges();
            }
        }
    }
}