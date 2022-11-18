using EMS.Business.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Departments> departments { get; set; }
    }

}
