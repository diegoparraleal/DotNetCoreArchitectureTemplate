using AseProject.Core;
using AseProject.Infrastructure.InMemory.DataProviders;
using AseProject.Infrastructure.InMemory.Repositories;
using AseProjects.Infrastructure.Contracts;
using AseProjects.Infrastructure.Contracts.Repositories;
using JetBrains.Annotations;

namespace AseProject.Infrastructure;

[UsedImplicitly]
public class Installer: IInstaller
{
    public IReadOnlyCollection<ServiceDependency> GetDependencies() =>
        new List<ServiceDependency>
        {
            ServiceDependency.Singleton<IDataProvider, InMemoryDataProvider>(),
            ServiceDependency.Singleton<ITodoRepository, TodoRepository>()
        };
}