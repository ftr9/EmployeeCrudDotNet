using EmployeeCrud.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Data
{
    public class EmployeeCrudDbContext : DbContext
    {
        public EmployeeCrudDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
    }

 

}
