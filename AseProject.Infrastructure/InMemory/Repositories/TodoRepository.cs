using AseProject.Domain.Todo;
using AseProjects.Infrastructure.Contracts.Repositories;

namespace AseProject.Infrastructure.InMemory.Repositories;

public class TodoRepository: GenericRepository<Todo>, ITodoRepository
{
}