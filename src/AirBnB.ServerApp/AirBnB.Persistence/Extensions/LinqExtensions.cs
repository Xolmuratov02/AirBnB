using AirBnB.Domain.Common.Entities;
using AirBnB.Domain.Common.Query;

namespace AirBnB.Persistence.Extensions;

public static class LinqExtensions
{
    public static IQueryable<TSource> ApplySpecification<TSource>(this IQueryable<TSource> source, QuerySpecification<TSource> querySpecification)
        where TSource : class, IEntity
    {
        source = source
            .ApplyPredicates(querySpecification)
            .ApplyOrdering(querySpecification)
            .ApplyIncluding(querySpecification)
            .ApplyPagination(querySpecification);

        return source;
    }

    public static IEnumerable<TSource> ApplySpecification<TSource>(this IEnumerable<TSource> source, QuerySpecification<TSource> querySpecification)
        where TSource : IEntity
    {
        source = source.ApplyPredicates(querySpecification).ApplyOrdering(querySpecification).ApplyPagination(querySpecification);

        return source;
    }

    public static IQueryable<TSource> ApplyPredicates<TSource>(this IQueryable<TSource> source, QuerySpecification<TSource> querySpecification)
        where TSource : IEntity
    {
        querySpecification.FilteringOptions.ForEach(predicate => source = source.Where(predicate));

        return source;
    }

    public static IEnumerable<TSource> ApplyPredicates<TSource>(this IEnumerable<TSource> source, QuerySpecification<TSource> querySpecification)
        where TSource : IEntity
    {
        querySpecification.FilteringOptions.ForEach(predicate => source = source.Where(predicate.Compile()));

        return source;
    }

    public static IQueryable<TSource> ApplyIncluding<TSource>(this IQueryable<TSource> source, QuerySpecification<TSource> querySpecification)
        where TSource : class, IEntity
    {
        var directIncludes = querySpecification.IncludingOptions.Where(includeOption => !includeOption.ToString().Contains('.')).ToList();
        var nonDirectIncludes = querySpecification.IncludingOptions.Where(includeOption => includeOption.ToString().Contains('.')).ToList();

        return source;
    }

    public static IQueryable<TSource> ApplyOrdering<TSource>(this IQueryable<TSource> source, QuerySpecification<TSource> querySpecification)
        where TSource : IEntity
    {
        if (querySpecification.OrderingOptions.Count == 0)
            return source.OrderBy(entity => entity.Id);

        querySpecification.OrderingOptions.ForEach(
            orderByExpression => source = orderByExpression.IsAscending
                ? source.OrderBy(orderByExpression.Item1)
                : source.OrderByDescending(orderByExpression.Item1)
        );

        return source;
    }

    public static IEnumerable<TSource> ApplyOrdering<TSource>(this IEnumerable<TSource> source, QuerySpecification<TSource> querySpecification)
        where TSource : IEntity
    {
        if (querySpecification.OrderingOptions.Count == 0)
            return source.OrderBy(entity => entity.Id);

        querySpecification.OrderingOptions.ForEach(
            orderByExpression => source = orderByExpression.IsAscending
                ? source.OrderBy(orderByExpression.Item1.Compile())
                : source.OrderByDescending(orderByExpression.Item1.Compile())
        );

        return source;
    }

    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source, QuerySpecification<TSource> querySpecification)
        where TSource : IEntity
    {
        return source.Skip((int)((querySpecification.PaginationOptions.PageToken - 1) * querySpecification.PaginationOptions.PageSize))
            .Take((int)querySpecification.PaginationOptions.PageSize);
    }

    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, QuerySpecification<TSource> querySpecification)
        where TSource : IEntity
    {
        return source.Skip((int)((querySpecification.PaginationOptions.PageToken - 1) * querySpecification.PaginationOptions.PageSize))
            .Take((int)querySpecification.PaginationOptions.PageSize);
    }

    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source, FilterPagination filterPagination)
        where TSource : IEntity
    {
        return source.Skip((int)((filterPagination.PageToken - 1) * filterPagination.PageSize)).Take((int)filterPagination.PageSize);
    }

    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, FilterPagination filterPagination)
        where TSource : IEntity
    {
        return source.Skip((int)((filterPagination.PageToken - 1) * filterPagination.PageSize)).Take((int)filterPagination.PageSize);
    }
}