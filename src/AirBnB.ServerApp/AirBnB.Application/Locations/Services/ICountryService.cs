using AirBnB.Application.Common.Queries.Models;
using AirBnB.Application.Locations.Models;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Locations.Services;

public interface ICountryService
{
    ValueTask<IList<Country>> GetAsync(
        CountryFilter filter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    );
}