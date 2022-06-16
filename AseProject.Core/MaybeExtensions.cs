using CSharpFunctionalExtensions;

namespace AseProject.Core;

public static class MaybeExtensions
{
    public static bool TryGet<T>(this Maybe<T> maybe, out T obj)
    {
        obj = maybe.Value;
        return maybe.HasValue;
    }
    
    public static Maybe<T> AsMaybe<T>(this T obj) => obj != null ? Maybe.From(obj): Maybe.None;
    
    public static Maybe<T> Cast<T>(object? obj) where T : class => obj is T tObj? Maybe.From(tObj): Maybe<T>.None;
    
    public static Maybe<T> MaybeCast<T>(this object obj) where T : class => Cast<T>(obj);
    
    public static Maybe<TOut> Then<T, TOut>(this Maybe<T> maybe, Func<T, TOut> predicate)
        => maybe.TryGet(out var obj) ? predicate(obj): Maybe<TOut>.None;
    
    public static T OrDefault<T>(this Maybe<T> maybe, Func<T> predicate) => maybe.GetValueOrDefault(predicate());
    
    public static T OrDefault<T>(this Maybe<T> maybe, T result) => maybe.GetValueOrDefault(result);
}