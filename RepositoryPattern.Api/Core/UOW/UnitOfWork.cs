using RepositoryPattern.Api.Core.Interfaces;
using RepositoryPattern.Api.Core.Repositories;
using RepositoryPattern.Api.Data;

namespace RepositoryPattern.Api.Core.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext _context;
        public IEmployeeRepository Employees { get; private set; }

        public IStudentRepository Students { get; private set; }


        public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger(categoryName: "logs");
            Employees = new EmployeeRepository(context, _logger);
            Students = new StudentRepository(context, _logger);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
