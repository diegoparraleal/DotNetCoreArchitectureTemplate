using CSharpFunctionalExtensions;

namespace AseProjects.Infrastructure.Contracts;

public interface IRepository<T>
{
    public Task<IReadOnlyCollection<T>> GetAllAsync();
    public Task<Maybe<T>> GetByIdAsync(int id);
    public Task<T> UpsertAsync(T item);
    public Task<bool> DeleteAsync(int id);
    public int Count { get; }
}