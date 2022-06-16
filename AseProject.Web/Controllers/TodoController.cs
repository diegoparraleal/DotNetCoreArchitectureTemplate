using AseProject.Business.Commands;
using AseProject.Business.Queries;
using AseProject.Domain.Todo;
using AseProjects.Infrastructure.Contracts.Loggers;
using Microsoft.AspNetCore.Mvc;

namespace AseProject.Web.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly IAddTodoItemCommand _addTodoItemCommand;
    private readonly ICheckTodoItemCommand _checkTodoItemCommand;
    private readonly IDeleteTodoItemCommand _deleteTodoItemCommand;
    private readonly ITodoQueries _todoQueries;
    private static readonly ILogger Log = Logger.Initialize<TodoController>();

    public TodoController(
        IAddTodoItemCommand addTodoItemCommand, 
        ICheckTodoItemCommand checkTodoItemCommand, 
        IDeleteTodoItemCommand deleteTodoItemCommand,
        ITodoQueries todoQueries)
    {
        _addTodoItemCommand = addTodoItemCommand;
        _checkTodoItemCommand = checkTodoItemCommand;
        _deleteTodoItemCommand = deleteTodoItemCommand;
        _todoQueries = todoQueries;
    }

    [HttpGet]
    public async Task<IEnumerable<Todo>> GetAllAsync() => await _todoQueries.GetAllAsync();

    [HttpPost]
    public async Task<Todo> AddTodoItemAsync([FromBody] AddTodoParameters parameters)
    {
        var result = await _addTodoItemCommand.ExecuteAsync(parameters);
        return result.Item;
    }

    [Route("{id}/check")]
    [HttpPut]
    public async Task<Todo> CheckTodoItemAsync([FromRoute] int id)
    {
        var result = await _checkTodoItemCommand.ExecuteAsync(new CheckTodoParameters(id));
        return result.Item;
    }
    
    [Route("{id}")]
    [HttpDelete]
    public async Task<bool> DeleteItemAsync([FromRoute] int id)
    {
        var result = await _deleteTodoItemCommand.ExecuteAsync(new DeleteTodoParameters(id));
        return result.Success;
    }
}