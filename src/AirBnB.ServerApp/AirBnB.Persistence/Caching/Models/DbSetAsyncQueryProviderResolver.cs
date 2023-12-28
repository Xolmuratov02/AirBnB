using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AirBnB.Persistence.Caching.Models;

public readonly struct DbSetAsyncQueryProviderResolver<TEntity>(DbSet<TEntity> dbSet) : IAsyncQueryProviderResolver where TEntity : class
{
    public IAsyncQueryProvider Get()
    {
        if (dbSet is not InternalDbSet<TEntity>)
            throw new ArgumentException("DbSet must be an InternalDbSet", nameof(dbSet));

        var entityQueryableMember = dbSet.GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(field => field.Name == "_entityQueryable");
        var entityQueryableInstance = entityQueryableMember.GetValue(dbSet) ?? throw new NullReferenceException("Entity queryable is null");

        // Get async query provider
        var asyncQueryProviderMember = entityQueryableInstance.GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(field => field.Name == "_queryProvider");
        var asyncQueryProviderInstance = asyncQueryProviderMember.GetValue(entityQueryableInstance) ??
                                         throw new NullReferenceException("Async query provider is null");

        return asyncQueryProviderInstance as IAsyncQueryProvider ?? throw new NullReferenceException("Async query provider is null");
    }
}