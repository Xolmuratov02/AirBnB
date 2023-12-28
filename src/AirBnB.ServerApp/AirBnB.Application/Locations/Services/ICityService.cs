using AirBnB.Application.Common.Queries.Models;
using AirBnB.Application.Locations.Models;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Locations.Services;

public interface ICityService
{
    ValueTask<IList<City>> GetAsync(CityFilter filter, QueryOptions queryOptions = new(), CancellationToken cancellationToken = default);
}