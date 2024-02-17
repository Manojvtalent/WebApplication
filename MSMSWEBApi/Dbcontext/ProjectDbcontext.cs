using Microsoft.EntityFrameworkCore;
using MSMSWEBApi.Models;

namespace MSMSWEBApi.Dbcontext
{
    public class ProjectDbcontext :DbContext
    {
        public ProjectDbcontext(DbContextOptions<ProjectDbcontext> options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
 