using AirBnB.Domain.Entities;
using System.Linq.Expressions;

namespace AirBnB.Persistence.Repositories.Interfaces;

public interface ICityRepository
{
    IQueryable<City> Get(Expression<Func<City, bool>>? predicate = null, bool asNoTracking = false);
}