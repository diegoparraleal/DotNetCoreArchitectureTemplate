namespace AseProject.Business;

public interface ICommonQuery<TOut>: IQueryAll<TOut>, IQueryById<TOut>
{
}