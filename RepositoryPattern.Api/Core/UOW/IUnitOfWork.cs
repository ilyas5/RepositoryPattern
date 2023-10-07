using RepositoryPattern.Api.Core.Interfaces;

namespace RepositoryPattern.Api.Core.UOW
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IStudentRepository Students { get; }
        Task CompleteAsync();

    }
}
