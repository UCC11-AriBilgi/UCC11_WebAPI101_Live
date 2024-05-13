using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Data
{
    public class AppDbContext : DbContext
    {
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
                
        }

        // Modellerimizin VT tarafındaki tablo karşılıkları
        public DbSet<Employee> Employees { get; set; }

    }
}
