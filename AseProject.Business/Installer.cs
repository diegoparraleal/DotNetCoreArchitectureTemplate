using AseProject.Business.Commands;
using AseProject.Business.Queries;
using AseProject.Core;
using JetBrains.Annotations;

namespace AseProject.Business;

[UsedImplicitly]
public class Installer: IInstaller
{
    public IReadOnlyCollection<ServiceDependency> GetDependencies() =>
        new List<ServiceDependency>
        {
            ServiceDependency.Singleton<IAddTodoItemCommand, AddTodoItemCommand>(),
            ServiceDependency.Singleton<ICheckTodoItemCommand, CheckTodoItemCommand>(),
            ServiceDependency.Singleton<IDeleteTodoItemCommand, DeleteTodoItemCommand>(),
            ServiceDependency.Singleton<ITodoQueries, TodoQueries>(),
        };
}