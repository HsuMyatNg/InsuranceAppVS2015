using InsuranceApp.Models;
using InsuranceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Services
{
    public class CustomersPolicyService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public void CreateCustomersPolicy(CustomersPolicyViewModel viewModel, string currentUserId)
        {
            CustomersPolicyModel model = new CustomersPolicyModel
            {
                Id = Guid.NewGuid(),
                CustomerId = viewModel.CustomerId,
                PolicyId = viewModel.PolicyId,
                Payment = viewModel.Payment,
                TotalInstallment = viewModel.TotalInstallment,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                Norminee = viewModel.Norminee,
                Related = viewModel.Related,
                Description = viewModel.Description,
                IsDeleted = false,
                Version = 1,
                CreatedUserId = currentUserId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = currentUserId

            };
            
            _context.CustomersPolicies.Add(model);
            _context.SaveChanges();
        }
        public List<CustomersPolicyViewModel> GetCustomersPolicy()
        {
            List<CustomersPolicyViewModel> model = _context.CustomersPolicies.Join(
                _context.RegisterUsers,
                c => c.CustomerId,
                r => r.Id,
                (c, r) => new { c, r }).Join(
                _context.Policies,
                cr => cr.c.PolicyId,
                p => p.Id,
                (cr, p) => new { cr, p })
                    .Select(crp => new CustomersPolicyViewModel
                    {
                        Id = crp.cr.c.Id,
                        CustomerId = crp.cr.c.CustomerId,
                        CustomerName = crp.cr.r.CustomerName,
                        NRCnumber = crp.cr.r.NRC,
                        PolicyId = crp.p.Id,
                        PolicyName = crp.p.Policy,
                        Payment = crp.cr.c.Payment,
                        TotalInstallment = crp.cr.c.TotalInstallment,
                        StartDate = crp.cr.c.StartDate,
                        EndDate = crp.cr.c.EndDate,
                        Norminee = crp.cr.c.Norminee,
                        Related = crp.cr.c.Related,
                        Description = crp.cr.c.Description

                    }).ToList();
            return model;

        }
        public CustomersPolicyViewModel CreateCustomersPolicyById(Guid id)
        {
            CustomersPolicyViewModel model = GetCustomersPolicy().Where(c => c.Id == id)
                .Select(c => c).FirstOrDefault();
            return model;
        }
        public void Edit(CustomersPolicyViewModel viewModel, string currentUserId)
        {
            CustomersPolicyModel entity = _context.CustomersPolicies.
                Where(c => c.Id == viewModel.Id)
                .Select(c => c).FirstOrDefault();
            if (entity != null)
            {
                /*entity.Id = viewModel.Id;*/
                entity.CustomerId = viewModel.CustomerId;
                entity.PolicyId = viewModel.PolicyId;
                entity.Payment = viewModel.Payment;
                entity.TotalInstallment = viewModel.TotalInstallment;
                entity.StartDate = viewModel.StartDate;
                entity.EndDate = viewModel.EndDate;
                entity.Norminee = viewModel.Norminee;
                entity.Related = viewModel.Related;
                entity.Description = viewModel.Description;
                entity.Version++;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedUserId = currentUserId;
            }
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            CustomersPolicyModel model = _context.CustomersPolicies.Where(c => c.Id == id)
                .Select(c => c).FirstOrDefault();
            if (model != null)
            {
                _context.CustomersPolicies.Remove(model);
                _context.SaveChanges();
            }
        }
      

    }
}