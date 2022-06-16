namespace AseProject.Business;

public interface IQueryAll<TOut>
{
    Task<IReadOnlyCollection<TOut>> GetAllAsync();
}