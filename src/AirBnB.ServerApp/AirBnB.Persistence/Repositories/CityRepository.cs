using AirBnB.Domain.Entities;
using AirBnB.Persistence.DataContexts;
using AirBnB.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace AirBnB.Persistence.Repositories;

public class CityRepository(AppDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<City, AppDbContext>(
    dbContext,
    cacheBroker,
    new CacheEntryOptions()
), ICityRepository
{
    public new IQueryable<City> Get(Expression<Func<City, bool>>? predicate = default, bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);
}