using AseProject.Core;
using AseProject.Domain.Todo;
using AseProjects.Infrastructure.Contracts.Repositories;

namespace AseProject.Business.Commands;

public record DeleteTodoParameters(int Id) : ICommandParameters;
public record DeleteTodoResult(bool Success) : ICommandResult;

public interface IDeleteTodoItemCommand: ICommand<DeleteTodoParameters, DeleteTodoResult> { }

public class DeleteTodoItemCommand : IDeleteTodoItemCommand
{
    private readonly ITodoRepository _repository;

    public DeleteTodoItemCommand(ITodoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<DeleteTodoResult> ExecuteAsync(DeleteTodoParameters parameters)
    {
        var maybeItem = await _repository.GetByIdAsync(parameters.Id);
        var item = maybeItem.GetValueOrThrow($"There is no item with id {parameters.Id}");
        var result = await _repository.DeleteAsync(item.Id);
        return new DeleteTodoResult(result);
    }
}