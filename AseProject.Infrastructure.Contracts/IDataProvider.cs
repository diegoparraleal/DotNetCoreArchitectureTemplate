using AseProjects.Infrastructure.Contracts.Repositories;

namespace AseProjects.Infrastructure.Contracts;

public interface IDataProvider
{
    public ITodoRepository Todos { get; }
}