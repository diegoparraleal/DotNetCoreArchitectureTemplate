namespace AseProject.Core;

public static class EnumerableExtensions
{
    public static IReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> items) 
        => items switch
        {
            IReadOnlyCollection<T> readOnlyCollection => readOnlyCollection,
            _ => new List<T>(items)
        };
}