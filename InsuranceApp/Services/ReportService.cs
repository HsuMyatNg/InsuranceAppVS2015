using InsuranceApp.Models;
using InsuranceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Services
{
    public class ReportService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public void CreateReports(ReportsViewModel viewModel, string currentUserId)
        {
            ReportModel model = new ReportModel
            {
                Id = Guid.NewGuid(),
                RegistrationId = viewModel.RegistrationId,
                PolicyId = viewModel.PolicyId,
                CustPolicyId = viewModel.CustPolicyId,
                CategoryId = viewModel.CategoryId,
                Date = viewModel.Date,
                IsDeleted = false,
                Version = 1,
                CreatedUserId = currentUserId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = currentUserId
            };
            _context.Reports.Add(model);
            _context.SaveChanges();
        }
        public List<ReportsViewModel> GetReports()
        {
            List<ReportsViewModel> model = _context.Reports.Join(
                _context.RegisterUsers,
                r => r.RegistrationId,
                u => u.Id,
                (r, u) => new { r, u }).Join(
                _context.Policies,
                ru => ru.r.PolicyId,
                p => p.Id,
                (ru, p) => new { ru, p }).Join(
                _context.CustomersPolicies,
                rup => rup.ru.r.CustPolicyId,
                c => c.Id,
                (rup, c) => new { rup, c }).Join(
                _context.Categories,
                rupc => rupc.rup.ru.r.CategoryId,
                g => g.Id,
                (rupc, g) => new { rupc, g })
                .Select(rupcg => new ReportsViewModel
                {
                    Id = rupcg.rupc.rup.ru.r.Id,
                    CustomerName = rupcg.rupc.rup.ru.u.CustomerName,
                    NRCnumber = rupcg.rupc.rup.ru.u.NRC,
                    PhoneNO = rupcg.rupc.rup.ru.u.PhoneNo,
                    PolicyName = rupcg.rupc.rup.p.Policy,
                    InsurancrType = rupcg.g.CategoryName,
                    TotalInstallment = rupcg.rupc.c.TotalInstallment,
                    Date = rupcg.rupc.rup.ru.r.Date,
                }).ToList();
            return model;
        }
        public ReportsViewModel GetReportsById(Guid id)
        {
            ReportsViewModel model = GetReports().Where(r => r.Id == id)
                .Select(r => r).FirstOrDefault();
            return model;
        }
        public void Edit(ReportsViewModel viewModel, string currentUserId)
        {
            ReportModel entity = _context.Reports
                .Where(r => r.Id == viewModel.Id)
                .Select(r => r).FirstOrDefault();
            if (entity != null)
            {
                entity.Id = viewModel.Id;
                entity.RegistrationId = viewModel.RegistrationId;
                entity.PolicyId = viewModel.PolicyId;
                entity.CustPolicyId = viewModel.CustPolicyId;
                entity.CategoryId = viewModel.CategoryId;
                entity.Date = viewModel.Date;
                entity.Version++;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedUserId = currentUserId;
            }
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            ReportModel model = _context.Reports.Where(r => r.Id == id)
                .Select(r => r).FirstOrDefault();
            if (model != null)
            {
                _context.Reports.Remove(model);
                _context.SaveChanges();
            }

        }
    }
        
}