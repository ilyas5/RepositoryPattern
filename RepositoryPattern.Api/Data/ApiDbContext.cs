using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Api.Models;

namespace RepositoryPattern.Api.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
    }
}
