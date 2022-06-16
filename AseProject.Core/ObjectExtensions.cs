namespace AseProject.Core;

public static class ObjectExtensions
{
    public static TOut Map<T, TOut>(this T obj, Func<T, TOut> predicate) => predicate(obj);
}