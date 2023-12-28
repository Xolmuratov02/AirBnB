using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using System.Linq.Expressions;

namespace AirBnB.Persistence.Caching.Models;

public class CachedQueryable<TSource, TQueryable> : IQueryable<TSource>, IAsyncEnumerable<TSource>
    where TQueryable : IQueryable<TSource>, IAsyncEnumerable<TSource>
{
    private readonly TQueryable _queryableSource;

    public CachedQueryable(
        TQueryable queryableSource,
        IAsyncQueryProviderResolver asyncQueryProvider,
        IExpressionCacheKeyResolver expressionCacheKeyResolver,
        IQueryCacheBroker queryCacheBroker
    )
    {
        _queryableSource = queryableSource;

        // Set element type and expression
        ElementType = _queryableSource.ElementType;
        Expression = _queryableSource.Expression;
        Provider = new CachedQueryProvider<TSource, TQueryable>(this, asyncQueryProvider.Get(), expressionCacheKeyResolver, queryCacheBroker);
    }

    public CachedQueryable(CachedQueryable<TSource, TQueryable> cachedQueryable, Expression expression)
    {
        ElementType = cachedQueryable.ElementType;
        Provider = cachedQueryable.Provider;
        _queryableSource = cachedQueryable._queryableSource;

        Expression = expression;
    }

    public IEnumerator<TSource> GetEnumerator() => _queryableSource.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Type ElementType { get; }

    public Expression Expression { get; }

    public IQueryProvider Provider { get; }

    public IAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default) =>
        ((IAsyncQueryProvider)Provider).ExecuteAsync<IAsyncEnumerable<TSource>>(Expression, cancellationToken).GetAsyncEnumerator(cancellationToken);
}