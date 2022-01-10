using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using InsuranceApp.Models;

namespace InsuranceApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<AdminAndStaffModel> AdminAndStaffs { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CustomersPolicyModel> CustomersPolicies { get; set; }
        public DbSet<PolicyModel> Policies { get; set; }
        public DbSet<RegisterForCustomersModel> RegisterUsers { get; set; }
        public DbSet<ReportModel> Reports { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<TownshipsModel> Townships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<AdminAndStaffModel>().ToTable("AdminAndStaffModel");
            modelBuilder.Entity<CategoryModel>().ToTable("CategoryModel");
            modelBuilder.Entity<CustomersPolicyModel>().ToTable("CustomersPolicyModel");
            modelBuilder.Entity<PolicyModel>().ToTable("PolicyModel");
            modelBuilder.Entity<RegisterForCustomersModel>().ToTable("RegisterForCustomersModel");
            modelBuilder.Entity<ReportModel>().ToTable("ReportModel");
            modelBuilder.Entity<CityModel>().ToTable("CityModel");
            modelBuilder.Entity<TownshipsModel>().ToTable("TownshipsModel");
        }
    }
}