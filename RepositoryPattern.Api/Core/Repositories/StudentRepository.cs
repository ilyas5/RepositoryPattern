using RepositoryPattern.Api.Core.GenericRepository;
using RepositoryPattern.Api.Core.Interfaces;
using RepositoryPattern.Api.Data;
using RepositoryPattern.Api.Models;

namespace RepositoryPattern.Api.Core.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
