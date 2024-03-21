using Microsoft.EntityFrameworkCore;

namespace Employee_CRUD_API.Entities
{
    public class EmployeeDbContext : DbContext
    {
        //Entites
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
           new Department { Id = 1, Name = "IT" },
           new Department { Id = 2, Name = "HR" },
           new Department { Id = 3, Name = "Payroll" },
           new Department { Id = 4, Name = "Admin" },
           new Department { Id = 5, Name = "Engineering" },
           new Department { Id = 6, Name = "Insurance & Healthcare" },
           new Department { Id = 7, Name = "Banking & Finance Services" },
           new Department { Id = 8, Name = "Retail & Logistics" }
       );


        }
    }
}
