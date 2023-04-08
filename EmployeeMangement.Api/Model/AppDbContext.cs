using EmployeeDetails.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Api.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT"}
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR"}    
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Sales" }
            );


            modelBuilder.Entity<Employee>().HasData(
                
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Venkata",
                    LastName = "Swaraj",
                    Email = "Venkatawaraj@gmail.com",
                    DateOfBirth = new DateTime(2001, 08, 06),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/Male2.png"

                }
            );

            modelBuilder.Entity<Employee>().HasData(
                
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Sathya",
                    LastName = "Damera",
                    Email = "Sathyadamera@yahoo.com",
                    DateOfBirth = new DateTime(2001, 08, 08),
                    Gender = Gender.Male,
                    DepartmentId = 2,
                    PhotoPath = "images/Male1.jpg"
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Shreya",
                    LastName = "Guptha",
                    Email = "shreyagupta@linkedin.com",
                    DateOfBirth = new DateTime(2003, 11, 10),
                    Gender = Gender.Female,
                    DepartmentId = 3,
                    PhotoPath = "images/Female1.png"
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Vaishnavi",
                    LastName = "Reddy",
                    Email = "vaishnavireddy@gmail.com",
                    DateOfBirth = new DateTime(2001, 10, 13),
                    Gender = Gender.Female,
                    DepartmentId = 4,
                    PhotoPath = "images/Female2.jpg"
                }
            );

        }

    }
}
