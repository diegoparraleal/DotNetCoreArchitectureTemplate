namespace AseProject.Domain.Todo;

public record Todo(int Id, string Name, bool Done) : IEntity
{
    public static Todo Build(int id, string name) => new (id, name, false);
}
