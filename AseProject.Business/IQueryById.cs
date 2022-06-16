namespace AseProject.Business;

public interface IQueryById<TOut>
{
    Task<TOut> GetByIdAsync(int id);
}