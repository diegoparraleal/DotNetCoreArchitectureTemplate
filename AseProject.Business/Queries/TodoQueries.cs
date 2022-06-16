using AseProject.Domain.Todo;
using AseProjects.Infrastructure.Contracts.Repositories;

namespace AseProject.Business.Queries;

public interface ITodoQueries: ICommonQuery<Todo> {}

public class TodoQueries: ITodoQueries
{
    private readonly ITodoRepository _repository;

    public TodoQueries(ITodoRepository repository)
    {
        _repository = repository;
    }
    
    public  Task<IReadOnlyCollection<Todo>> GetAllAsync() => _repository.GetAllAsync();

    public async Task<Todo> GetByIdAsync(int id) 
        => (await _repository.GetByIdAsync(id)).GetValueOrThrow($"Element with id {id} not found");
}