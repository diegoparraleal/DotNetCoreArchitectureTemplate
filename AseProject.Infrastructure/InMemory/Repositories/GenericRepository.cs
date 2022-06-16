using AseProject.Core;
using AseProject.Domain;
using AseProjects.Infrastructure.Contracts;
using CSharpFunctionalExtensions;

namespace AseProject.Infrastructure.InMemory.Repositories;

public abstract class GenericRepository<T>: IRepository<T> where T: IEntity
{
    private Dictionary<int, T> _store = new();

    public Task<IReadOnlyCollection<T>> GetAllAsync() => _store.Values.AsReadOnlyTask();

    public Task<Maybe<T>> GetByIdAsync(int id) => _store.TryFind(id).AsTask();

    public Task<T> UpsertAsync(T item)
    {
        if (_store.ContainsKey(item.Id)) _store[item.Id] = item;
        else _store.Add(item.Id, item);

        return item.AsTask();
    }

    public Task<bool> DeleteAsync(int id) => _store.Remove(id).AsTask();

    public int Count => _store.Count;
}