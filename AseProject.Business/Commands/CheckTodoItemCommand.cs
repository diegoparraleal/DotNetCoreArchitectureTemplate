using AseProject.Core;
using AseProject.Domain.Todo;
using AseProjects.Infrastructure.Contracts.Repositories;

namespace AseProject.Business.Commands;

public record CheckTodoParameters(int Id) : ICommandParameters;
public record CheckTodoResult(Todo Item) : ICommandResult;

public interface ICheckTodoItemCommand: ICommand<CheckTodoParameters, CheckTodoResult> { }

public class CheckTodoItemCommand : ICheckTodoItemCommand
{
    private readonly ITodoRepository _repository;

    public CheckTodoItemCommand(ITodoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<CheckTodoResult> ExecuteAsync(CheckTodoParameters parameters)
    {
        var maybeItem = await _repository.GetByIdAsync(parameters.Id);
        var item = maybeItem.GetValueOrThrow($"There is no item with id {parameters.Id}");
        var result = await _repository.UpsertAsync(item with { Done = true});
        return result.Map(x => new CheckTodoResult(x));
    }
}