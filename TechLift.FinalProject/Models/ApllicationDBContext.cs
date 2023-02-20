using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechLift.FinalProject.Models
{
    public class ApllicationDBContext : IdentityDbContext<User>
    {
        public ApllicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(UserSead());

            modelBuilder.Entity<Department>().HasData(DepartmentSead());
            base.OnModelCreating(modelBuilder);
        }
        private Department[] DepartmentSead()
        {
            List<Department> departments = new()
            {
                    new Department
                    {
                      Id = 1,
                      Name= "Accounts",
                    },
                     new Department
                    {
                      Id = 2,
                      Name= "Operations",
                    },
                      new Department
                    {
                      Id = 3,
                      Name= "Marketing",
                    },
                    new Department
                    {
                      Id = 4,
                      Name= "Sales",
                    }

            };
            return departments.ToArray();
        }
        private User[] UserSead()
        {
            List<User> users = new()
            {
                    new User
                    {
                      Id = "1",
                      Firstname= "Awais",
                      Lastname= "Awan",
                      Deleted= false,
                      UserName= "Awais",
                      NormalizedUserName= "AWAIS",
                      Email= "admin@gmail.com",
                      NormalizedEmail= "admin@gmail.com",
                      EmailConfirmed= true,
                      PasswordHash= "AQAAAAEAACcQAAAAEMWYn+mZkkjtGIUVVPBiZW0oe8e60oJ0t+G5uMIwfbBIRlcTqpBPXSCvEwWmo1v0ug==",
                      SecurityStamp= "QPHY6ZG4LMBODR36AM3C4UHGDBRMYOX7",
                      ConcurrencyStamp= "8035c690-70d8-4c9d-82c4-104bd0b2dcaf",
                      PhoneNumber= "03234234",
                      PhoneNumberConfirmed=true,
                      TwoFactorEnabled=true,
                      LockoutEnabled= false,
                      AccessFailedCount= 0,
                    }

            };
            return users.ToArray();
        }
    }
}

