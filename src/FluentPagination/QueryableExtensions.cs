namespace FluentPagination;

public static class QueryableExtensions
{
    public static IQueryable<T> FirstPage<T>(this IQueryable<T> query, int pageSize)
        => query.Take(pageSize);
}