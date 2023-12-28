using AirBnB.Domain.Common.Entities;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Exceptions;
using AirBnB.Persistence.Caching.Brokers;
using AirBnB.Persistence.Caching.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Linq.Expressions;

namespace AirBnB.Persistence.Repositories;

public class EntityRepositoryBase<TEntity, TContext>(TContext dbContext, ICacheBroker cacheBroker, CacheEntryOptions? cacheEntryOptions = default)
    where TEntity : class, IEntity where TContext : DbContext
{
    protected TContext DbContext => dbContext;
    protected DbSetAsyncQueryProviderResolver<TEntity> AsyncQueryProviderResolver => new(DbContext.Set<TEntity>());

    protected IQueryable<TEntity> QuerySource =>
        cacheEntryOptions is null
            ? DbContext.Set<TEntity>()
            : DbContext.Set<TEntity>()
                .AddCaching(AsyncQueryProviderResolver, new EfCoreExpressionCacheKeyResolver(), cacheBroker.GetCacheResolver(cacheEntryOptions));

    protected async ValueTask<IList<TEntity>> GetAsync(QuerySpecification<TEntity> querySpecification, CancellationToken cancellationToken = default)
    {
        var cacheKey = querySpecification.CacheKey;

        if (cacheEntryOptions is not null)
        {
            var test = await cacheBroker.TryGetAsync<List<TEntity>>(cacheKey, cancellationToken);
            if (test.Result) return test.Value!;
        }

        var initialQuery = DbContext.Set<TEntity>().AsQueryable();

        if (querySpecification.AsNoTracking) initialQuery = initialQuery.AsNoTracking();
        initialQuery = initialQuery.ApplySpecification(querySpecification);
        var foundEntities = await initialQuery.ToListAsync(cancellationToken);

        if (cacheEntryOptions is not null) await cacheBroker.SetAsync(cacheKey, foundEntities, cacheEntryOptions, cancellationToken);

        return foundEntities;
    }

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = null, bool asNoTracking = false)
    {
        var initialQuery = asNoTracking ? QuerySource.AsNoTracking() : QuerySource;

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        return initialQuery;

        return predicate is null ? initialQuery : initialQuery.Where(predicate);
    }

    private static async ValueTask<T?> ExecuteAsync<T>(Guid entityId, Func<Task<T?>> dataAccessFunc)
    {
        var result = await dataAccessFunc.GetValueAsync();
        if (!result.IsSuccess)
            throw MapEfCoreException(entityId, result.Exception!);

        return result.Data;
    }

    private static Exception MapEfCoreException(Guid entityId, Exception exception)
    {
        return exception switch
        {
            DbUpdateConcurrencyException dbUpdateConcurrencyException => new EntityConflictException<TEntity>(entityId, dbUpdateConcurrencyException),
            DbUpdateException dbUpdateException => MapDbUpdateException(entityId, dbUpdateException),
            _ => exception
        };
    }

    private static EntityExceptionBase MapDbUpdateException(Guid entityId, DbUpdateException exception)
    {
        if (exception.InnerException is not NpgsqlException postgresException)
            return new EntityExceptionBase(entityId, innerException: exception);

        switch (postgresException.ErrorCode)
        {
            case 547: // foreign key constraint violation
            case 2601: // unique constraint violation for index
            case 2627: // unique constraint violation for primary key
                throw new EntityConflictException<TEntity>(entityId, exception);
            default:
                throw new EntityExceptionBase(entityId, innerException: exception);
        }
    }
}