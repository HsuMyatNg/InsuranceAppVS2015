using InsuranceApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(InsuranceApp.Startup))]
namespace InsuranceApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateInitialRole();
        }
        public void CreateInitialRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (!context.Database.Exists())
            {
                #region Create Roles
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                //if (!roleManager.RoleExists("Admin")) { }                              
                roleManager.Create(new IdentityRole() { Name = "Admin" });
                roleManager.Create(new IdentityRole() { Name = "Staff" });
                #endregion

                #region create admin 
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var adminUser = new ApplicationUser() { UserName = "admin@gmail.com", Email = "admin@gmail.com" };
                string userPassword = "Admin@123";
                var chkUser = userManager.Create(adminUser, userPassword);
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(adminUser.Id, "Admin");
                }


                var staffUser = new ApplicationUser() { UserName = "staff@gmail.com", Email = "staff@gmail.com" };
                string staffUserPWD = "Staff@123";
                chkUser = userManager.Create(staffUser, staffUserPWD);//only user create
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(staffUser.Id, "Staff");
                }
                #endregion
                var now = DateTime.Now;
                var user = userManager.FindByName("admin@gmail.com");
                Guid ygnId = Guid.NewGuid();
                Guid mykId = Guid.NewGuid();
                Guid dwId = Guid.NewGuid();

                CityModel ygnCity = new CityModel
                {
                    Id = ygnId,
                    Name = "Yangon",
                    IsDeleted = false,
                    Version = 1,
                    CreatedDate = now,
                    UpdatedDate = now,
                    CreatedUserId = user.Id,
                    UpdatedUserId = user.Id

                };
                CityModel mykCity = new CityModel
                {
                    Id = mykId,
                    Name = "Myeik",
                    IsDeleted = false,
                    Version = 1,
                    CreatedDate = now,
                    UpdatedDate = now,
                    CreatedUserId = user.Id,
                    UpdatedUserId = user.Id

                };
                CityModel dwCity = new CityModel
                {
                    Id = dwId,
                    Name = "Dawei",
                    IsDeleted = false,
                    Version = 1,
                    CreatedDate = now,
                    UpdatedDate = now,
                    CreatedUserId = user.Id,
                    UpdatedUserId = user.Id

                };
                context.Cities.Add(ygnCity);
                context.Cities.Add(mykCity);
                context.Cities.Add(dwCity);
                context.SaveChanges();

                #region add Townships
                Guid hlaingId = Guid.NewGuid();
                Guid inseinId = Guid.NewGuid();
                Guid tnyId = Guid.NewGuid();
                Guid palaId = Guid.NewGuid();
                Guid yayId = Guid.NewGuid();
                Guid paloukId = Guid.NewGuid();
                TownshipsModel hlaingTownship = new TownshipsModel
                {
                    Id = hlaingId,
                    TownshipName = "Hlaing",
                    CityId = ygnId,
                    IsDeleted = false,
                    Version = 1,
                    CreatedDate = now,
                    UpdatedDate = now,
                    CreatedUserId = user.Id,
                    UpdatedUserId = user.Id

                };
                TownshipsModel inseinTownship = new TownshipsModel
                {
                    Id = inseinId,
                    TownshipName = "Insein",
                    CityId = ygnId,
                    IsDeleted = false,
                    Version = 1,
                    CreatedDate = now,
                    UpdatedDate = now,
                    CreatedUserId = user.Id,
                    UpdatedUserId = user.Id
                };

                TownshipsModel palaTownship = new TownshipsModel
                {
                    Id = palaId,
                    TownshipName = "Pala",
                    CityId = mykId,
                    IsDeleted = false,
                    Version = 1,
                    CreatedDate = now,
                    UpdatedDate = now,
                    CreatedUserId = user.Id,
                    UpdatedUserId = user.Id
                };
                TownshipsModel thanintharyiTownship = new TownshipsModel
                {
                    Id = tnyId,
                    TownshipName = "Thanintharyi",
                    CityId = mykId,
                    IsDeleted = false,
                    Version = 1,
                    CreatedDate = now,
                    UpdatedDate = now,
                    CreatedUserId = user.Id,
                    UpdatedUserId = user.Id
                };

                TownshipsModel paloukTownship = new TownshipsModel
                {
                    Id = paloukId,
                    TownshipName = "Palouk",
                    CityId = dwId,
                    IsDeleted = false,
                    Version = 1,
                    CreatedDate = now,
                    UpdatedDate = now,
                    CreatedUserId = user.Id,
                    UpdatedUserId = user.Id
                };

                TownshipsModel yayTownship = new TownshipsModel
                {
                    Id = yayId,
                    TownshipName = "Yay",
                    CityId = dwId,
                    IsDeleted = false,
                    Version = 1,
                    CreatedDate = now,
                    UpdatedDate = now,
                    CreatedUserId = user.Id,
                    UpdatedUserId = user.Id
                };
                context.Townships.Add(hlaingTownship);
                context.Townships.Add(inseinTownship);
                context.Townships.Add(palaTownship);
                context.Townships.Add(thanintharyiTownship);
                context.Townships.Add(paloukTownship);
                context.Townships.Add(yayTownship);
                context.SaveChanges();

                #endregion
            }
        }
    }
}
