using InsuranceApp.Models;
using InsuranceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Services
{
    public class PolicyService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public void CreatePolicy(PolicyViewModel viewModel,string currentUserId)
        {
            PolicyModel entitly = new PolicyModel
            {
                Id=Guid.NewGuid(),
                Policy=viewModel.Policy,
                CategoryId=viewModel.CategoryId,
                Duration=viewModel.Duration,
                Cost=viewModel.Cost,
                Description=viewModel.Description,
                IsDeleted = false,
                Version = 1,
                CreatedUserId = currentUserId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = currentUserId

            };
            _context.Policies.Add(entitly);
            _context.SaveChanges();
        }
        public List<PolicyViewModel> GetPolicies()
        {
            List<PolicyViewModel> policies = _context.Policies.Join(
                _context.Categories,
                p => p.CategoryId,
                c => c.Id,
                (p,c) => new {p,c})
                 .Select(pc => new PolicyViewModel
                 {
                     Id=pc.p.Id,
                     Policy=pc.p.Policy,
                     PolicyType=pc.c.CategoryName,
                     Duration=pc.p.Duration,
                     Cost=pc.p.Cost,
                     Description=pc.p.Description
                 }).ToList();
            return policies;
        }
        public PolicyViewModel GetPoliciesById(Guid id)
        {
            PolicyViewModel model = GetPolicies().Where(p => p.Id == id)
                .Select(p => p).FirstOrDefault();
            return model;
        }
        public void EditPolicy(PolicyViewModel viewModel,string currentUserId)
        {
            PolicyModel entity = _context.Policies
                .Where(p => p.Id == viewModel.Id)
                .Select(p => p).FirstOrDefault();
            if(entity!=null)
            {
                entity.Id = viewModel.Id;
                entity.Policy = viewModel.Policy;
                entity.CategoryId = viewModel.CategoryId;
                entity.Duration = viewModel.Duration;
                entity.Cost = viewModel.Cost;
                entity.Description = viewModel.Description;
                entity.Version++;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedUserId = currentUserId;
                _context.SaveChanges();

            }
        }
        public void Delete(Guid id,string currentUserId)
        {
            PolicyModel entity = _context.Policies.Where(p => p.Id == id)
                .Select(p => p).FirstOrDefault();
            if (entity != null)
            {
                _context.Policies.Remove(entity);
                _context.SaveChanges();
            }


        }
        public List<PolicyViewModel> GetPoliciesForDropdown()
        {
            List<PolicyViewModel> policies = _context.Policies
                .Where(b => !b.IsDeleted)
                .Select(b => new PolicyViewModel
                {
                    Id = b.Id,
                    Policy = b.Policy
                })
                .ToList();
            return policies;
        }


    }
}