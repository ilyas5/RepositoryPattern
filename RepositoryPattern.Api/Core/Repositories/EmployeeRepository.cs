using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Api.Core.GenericRepository;
using RepositoryPattern.Api.Core.Interfaces;
using RepositoryPattern.Api.Data;
using RepositoryPattern.Api.Models;

namespace RepositoryPattern.Api.Core.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<List<Employee>> GetAllAsync()
        {
            return await context.Employees.ToListAsync();
        }



    }
}
