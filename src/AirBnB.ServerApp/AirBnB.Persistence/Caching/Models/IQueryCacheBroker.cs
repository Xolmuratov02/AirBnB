namespace AirBnB.Persistence.Caching.Models;

public interface IQueryCacheBroker
{
    Task<TResult> GetOrSetAsync<TResult, TActual>(string key, Func<Task<TResult>> valueFactory) where TResult : class;

    TResult GetOrSet<TResult, TActual>(string key, Func<TResult> valueFactory) where TResult : class;
}