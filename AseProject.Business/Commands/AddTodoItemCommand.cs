using AseProject.Core;
using AseProject.Domain.Todo;
using AseProjects.Infrastructure.Contracts.Repositories;

namespace AseProject.Business.Commands;

public record AddTodoParameters(string Name) : ICommandParameters;
public record AddTodoResult(Todo Item) : ICommandResult;

public interface IAddTodoItemCommand: ICommand<AddTodoParameters, AddTodoResult> { }

public class AddTodoItemCommand : IAddTodoItemCommand
{
    private readonly ITodoRepository _repository;

    public AddTodoItemCommand(ITodoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<AddTodoResult> ExecuteAsync(AddTodoParameters parameters)
    {
        var numItems = _repository.Count;
        var result = await _repository.UpsertAsync(Todo.Build(numItems + 1, parameters.Name));
        return result.Map(x => new AddTodoResult(x));
    }
}