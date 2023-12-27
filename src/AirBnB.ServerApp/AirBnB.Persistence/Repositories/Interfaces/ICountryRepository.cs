using AirBnB.Domain.Entities;
using System.Linq.Expressions;

namespace AirBnB.Persistence.Repositories.Interfaces;

public interface ICountryRepository
{
    IQueryable<Country> Get(Expression<Func<Country, bool>>? predicate = null, bool asNoTracking = false);
}