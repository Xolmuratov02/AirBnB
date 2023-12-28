namespace AirBnB.Persistence.Caching.Models;

public struct CacheEntryOptions
{
    public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }

    public TimeSpan? SlidingExpiration { get; set; }
}