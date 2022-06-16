namespace AseProject.Business;

public interface IQueryByName<TOut>
{
    Task<TOut> GetByNameAsync(string name);
}