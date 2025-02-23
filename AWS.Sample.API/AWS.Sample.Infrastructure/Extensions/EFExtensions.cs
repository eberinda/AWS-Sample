using System.Linq.Expressions;

namespace AWS.Sample.Infrastructure.Extensions;

public static class EFExtensions
{
    public static IQueryable<T> WhereWhen<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
    {
        return condition ? query.Where(predicate) : query;
    }
}