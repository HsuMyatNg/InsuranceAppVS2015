using InsuranceApp.Models;
using InsuranceApp.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp.Services
{
 
    public class AdminAndStaffService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public List<AdminAndStaffViewModel> GetAdminAndStaffList()
        {
            List<AdminAndStaffViewModel> results = _context.AdminAndStaffs.
                Select(a => new AdminAndStaffViewModel
                {
                    Id=a.Id,
                    UserName=a.UserName,
                    PhoneNo=a.PhoneNo,
                    Roll=a.Roll,
                    Email=a.Email,
                    Upwd=a.Upwd,
                    FirstPart=a.FirstPart,
                    SecondPart=a.SecondPart,
                    NRCnumber=a.NRCnumber,
                    DOB=a.DOB,
                    Gender=a.Gender

                }).ToList();

            return results;
        }
        public void CreateAdminAndStaff(AdminAndStaffViewModel viewModel)
        {
           
            AdminAndStaffModel entity = new AdminAndStaffModel
            {
                Id = Guid.NewGuid(),
                UserName=viewModel.UserName,
                PhoneNo=viewModel.PhoneNo,
                Roll=viewModel.Roll,
                Email=viewModel.Email,
                Upwd=viewModel.Upwd,
                FirstPart=viewModel.FirstPart,
                SecondPart=viewModel.SecondPart,
                NRCnumber=viewModel.NRCnumber,
                NRC=viewModel.FirstPart+"/"+viewModel.SecondPart+"(N)"+viewModel.NRCnumber,
                DOB=viewModel.DOB,
                Gender=viewModel.Gender,
                IsDeleted = false,
                Version = 1,
                CreatedUserId = viewModel.CurrentUserId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = viewModel.CurrentUserId
                
            };
            _context.AdminAndStaffs.Add(entity);
            _context.SaveChanges();
        }
        public AdminAndStaffViewModel GetDataById(Guid id)
        {
            AdminAndStaffViewModel entity = GetAdminAndStaffList().Where(a => a.Id == id).
                Select(a => a).FirstOrDefault();
            return entity;
        } 
        public void EditAdminAndStaff(AdminAndStaffViewModel viewModel)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            AdminAndStaffModel entity=_context.AdminAndStaffs.Where(a => a.Id == viewModel.Id)
                .Select(a => a).FirstOrDefault();
         
            if (entity!=null)
            {
                var userEntity = _context.Users.Where(u => u.Email == entity.Email).Select(u => u).FirstOrDefault();
                if(userEntity!=null)
                {
                    userEntity.Email = viewModel.Email;
                    userEntity.UserName = viewModel.Email;
                    string userId = (viewModel.Id).ToString();
                    
                    entity.Id = viewModel.Id;
                    entity.UserName = viewModel.UserName;
                    entity.PhoneNo = viewModel.PhoneNo;
                    entity.Roll = viewModel.Roll;
                    entity.Email = viewModel.Email;
                    entity.Upwd = viewModel.Upwd;
                    entity.FirstPart = viewModel.FirstPart;
                    entity.SecondPart = viewModel.SecondPart;
                    entity.NRCnumber = viewModel.NRCnumber;
                    entity.NRC = viewModel.FirstPart + "/" + viewModel.SecondPart + "(N)" + viewModel.NRCnumber;
                    entity.DOB = viewModel.DOB;
                    entity.Gender = viewModel.Gender;
                    entity.Version++;
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedUserId = viewModel.CurrentUserId;

                  
                    _context.SaveChanges();
                }
                
            }
        }
        public void DeleteAdminAndStaff(Guid id)
        {
            AdminAndStaffModel entity= _context.AdminAndStaffs
                .Where(a => a.Id == id).Select(a => a)
                .FirstOrDefault();
            if(entity!=null)
            {
                var userEntity=_context.Users.Where(a => a.Email ==entity.Email).Select(a => a)
                .FirstOrDefault();
                if(userEntity!=null)
                {
                    _context.Users.Remove(userEntity);
                    _context.AdminAndStaffs.Remove(entity);
                    _context.SaveChanges();
                }
               
            }
        }

        public void ChangePassword(string id,string changePassword)
        {
            //AdminAndStaffModel entity=_context.AdminAndStaffs.Where(a=>a.Id == new Guid(id)).Select(a => a).FirstOrDefault();
            //if(entity!=null)
            //{
            //    entity.Upwd = changePassword;
            //    _context.SaveChanges();
            //}
            var userEntity=_context.Users.Where(u => u.Id == id).Select(u => u).FirstOrDefault();
            if(userEntity!=null)
            {
                AdminAndStaffModel adminEntity=_context.AdminAndStaffs.Where(a => a.Email == userEntity.Email)
                    .Select(a => a).FirstOrDefault();
                if(adminEntity!=null)
                {
                    adminEntity.Upwd = changePassword;
                    _context.SaveChanges();
                }

            }
        }


    }
}