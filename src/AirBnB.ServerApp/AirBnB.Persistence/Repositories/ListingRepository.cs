using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Caching.Brokers;
using AirBnB.Persistence.Caching.Models;
using AirBnB.Persistence.DataContexts;
using AirBnB.Persistence.Repositories.Interfaces;

namespace AirBnB.Persistence.Repositories;

public class ListingRepository(AppDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<Listing, AppDbContext>(
    dbContext,
    cacheBroker,
    new CacheEntryOptions()
), IListingRepository
{
    public new ValueTask<IList<Listing>> GetAsync(QuerySpecification<Listing> querySpecification, CancellationToken cancellationToken = default)
    {
        return base.GetAsync(querySpecification, cancellationToken);
    }
}