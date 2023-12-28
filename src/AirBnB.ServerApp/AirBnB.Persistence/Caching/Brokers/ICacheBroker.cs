using AirBnB.Persistence.Caching.Models;

namespace AirBnB.Persistence.Caching.Brokers;

public interface ICacheBroker
{
    ValueTask<T?> GetAsync<T>(string key);

    ValueTask<T?> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? entryOptions = default);

    ValueTask<(bool Result, T? Value)> TryGetAsync<T>(string key, CancellationToken cancellationToken = default);

    ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? entryOptions = default, CancellationToken cancellationToken = default);

    IQueryCacheBroker GetCacheResolver(CacheEntryOptions? entryOptions = default);
}