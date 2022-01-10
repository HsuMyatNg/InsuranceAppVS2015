using InsuranceApp.Models;
using InsuranceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Services
{
    public class RegisterForCustomersService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public void CreateCustomers(RegisterForCustomersViewModel viewModel,string Img,string currentUserId)
        {
            RegisterForCustomersModel model = new RegisterForCustomersModel
            {
                Id = Guid.NewGuid(),
                CustomerName=viewModel.CustomerName,
                FirstPart = viewModel.FirstPart,
                SecondPart = viewModel.SecondPart,
                NRCnumber = viewModel.NRCnumber,
                NRC = viewModel.FirstPart + "/" + viewModel.SecondPart + "(N)" + viewModel.NRCnumber,
                PhoneNo =viewModel.PhoneNo,
                Email=viewModel.Email,
                CityId=viewModel.CityId,
                TownshipId=viewModel.TownshipId,
                Address=viewModel.Address,
                DOB=viewModel.DOB,
                Gender=viewModel.Gender,
                photo= Img,
                IsDeleted = false,
                Version = 1,
                CreatedUserId = currentUserId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = currentUserId

            };
            _context.RegisterUsers.Add(model);
            _context.SaveChanges();
        }
        public List<RegisterForCustomersViewModel> GetCustomers()
        {
            List<RegisterForCustomersViewModel> model = _context.RegisterUsers.Join(
               _context.Cities,
            r => r.CityId,
            c => c.Id,
            (r, c) => new { r, c })
            .Join(
                _context.Townships,
            rc => rc.r.TownshipId,
            t => t.Id,
            (rc, t) => new { rc, t })
            .Select(rct => new RegisterForCustomersViewModel
            {
                Id = rct.rc.r.Id,
                CustomerName = rct.rc.r.CustomerName,
                FirstPart = rct.rc.r.FirstPart,
                SecondPart = rct.rc.r.SecondPart,
                NRCnumber = rct.rc.r.NRCnumber,
                PhoneNo = rct.rc.r.PhoneNo,
                Email = rct.rc.r.Email,
                CityId = rct.rc.r.CityId,
                CityName =rct.rc.c.Name,
                TownshipId=rct.rc.r.TownshipId,
                TownshipName = rct.t.TownshipName,
                Address = rct.rc.r.Address,
                DOB = rct.rc.r.DOB,
                Gender = rct.rc.r.Gender,
                photo = rct.rc.r.photo,

            }).ToList();
            //List <RegisterForCustomersViewModel> model = _context.RegisterUsers.
            //    Select(r => new RegisterForCustomersViewModel
            //    {
            //        Id=r.Id,
            //        CustomerName=r.CustomerName,
            //        PhoneNo=r.PhoneNo,
            //        Email=r.Email,
            //        CityId=r.CityId,
            //        TownshipId=r.TownshipId,
            //        Address=r.Address,
            //        DOB=r.DOB,
            //        Gender=r.Gender,
            //        photo= r.photo,
               
            //    })
            //    .ToList();
            return model;
        }
        public RegisterForCustomersViewModel GetCustomerById(Guid id)
        {
            RegisterForCustomersViewModel model = GetCustomers().Where(r => r.Id == id)
                .Select(r => r).FirstOrDefault();
            return model;
        }
        public void Edit(RegisterForCustomersViewModel viewModel,string img,string currentUserId)
        {
            RegisterForCustomersModel entity = _context.RegisterUsers
                .Where(r => r.Id == viewModel.Id)
                .Select(r => r).FirstOrDefault();
            if(entity!=null)
            {
                entity.Id = viewModel.Id;
                entity.CustomerName = viewModel.CustomerName;
                entity.FirstPart = viewModel.FirstPart;
                entity.SecondPart = viewModel.SecondPart;
                entity.NRCnumber = viewModel.NRCnumber;
                entity.NRC = viewModel.FirstPart + "/" + viewModel.SecondPart + "(N)" + viewModel.NRCnumber;
                entity.PhoneNo = viewModel.PhoneNo;
                entity.Email = viewModel.Email;
                entity.CityId = viewModel.CityId;
                entity.TownshipId = viewModel.TownshipId;
                entity.Address = viewModel.Address;
                entity.DOB = viewModel.DOB;
                entity.Gender = viewModel.Gender;
                entity.photo = img;
                entity.Version++;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedUserId = currentUserId;
            }
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            RegisterForCustomersModel model = _context.RegisterUsers.Where(r => r.Id == id)
                .Select(r => r).FirstOrDefault();
            if(model!=null)
            {
                _context.RegisterUsers.Remove(model);
                _context.SaveChanges();
            }
                
        }
        public List<RegisterForCustomersViewModel> GetRegCustomersForDropdown()
        {
            List<RegisterForCustomersViewModel> customers = _context.RegisterUsers
                .Where(r => !r.IsDeleted)
                .Select(r => new RegisterForCustomersViewModel
                {
                    Id = r.Id,
                    CustomerName = r.CustomerName,
                    NRCnumber = r.NRC
                })
                .ToList();
            return customers;
        }


    }
}