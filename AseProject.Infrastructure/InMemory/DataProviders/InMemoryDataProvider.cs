using AseProject.Infrastructure.InMemory.Repositories;
using AseProjects.Infrastructure.Contracts;
using AseProjects.Infrastructure.Contracts.Repositories;
using JetBrains.Annotations;

namespace AseProject.Infrastructure.InMemory.DataProviders;

[UsedImplicitly]
public class InMemoryDataProvider: IDataProvider
{
    public ITodoRepository Todos { get; }

    public InMemoryDataProvider()
    {
        Todos = new TodoRepository();
    }
}