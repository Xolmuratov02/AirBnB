using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Persistence.Caching.Models;

public static class EfCoreExtensions
{
    public static IQueryable<TEntity> AddCaching<TEntity>(
        this DbSet<TEntity> dbSet,
        IAsyncQueryProviderResolver asyncQueryProviderResolver,
        IExpressionCacheKeyResolver expressionCacheKeyResolver,
        IQueryCacheBroker queryCacheBroker
    ) where TEntity : class
    {
        if (dbSet is not InternalDbSet<TEntity> internalDbSet)
            throw new ArgumentException("DbSet must be an InternalDbSet", nameof(dbSet));

        return new CachedQueryable<TEntity, InternalDbSet<TEntity>>(
            internalDbSet,
            asyncQueryProviderResolver,
            expressionCacheKeyResolver,
            queryCacheBroker
        );
    }
}