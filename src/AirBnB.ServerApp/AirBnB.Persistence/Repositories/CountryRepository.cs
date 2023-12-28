using AirBnB.Domain.Entities;
using AirBnB.Persistence.Caching.Brokers;
using AirBnB.Persistence.Caching.Models;
using AirBnB.Persistence.DataContexts;
using AirBnB.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace AirBnB.Persistence.Repositories;

public class CountryRepository(AppDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<Country, AppDbContext>(
    dbContext,
    cacheBroker,
    new CacheEntryOptions()
), ICountryRepository
{
    public new IQueryable<Country> Get(Expression<Func<Country, bool>>? predicate = null, bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);
}