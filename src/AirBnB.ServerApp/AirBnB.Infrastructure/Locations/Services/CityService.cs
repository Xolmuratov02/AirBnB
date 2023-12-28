using AirBnB.Application.Common.Queries.Models;
using AirBnB.Application.Locations.Models;
using AirBnB.Application.Locations.Services;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Extensions;
using AirBnB.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Infrastructure.Locations.Services;

public class CityService(ICityRepository cityRepository) : ICityService
{
    public async ValueTask<IList<City>> GetAsync(CityFilter filter, QueryOptions queryOptions = new(), CancellationToken cancellationToken = default)
    {
        var initialQuery = cityRepository.Get(asNoTracking: queryOptions.AsNoTracking);

        if (filter.SearchKeyword is not null)
            initialQuery = initialQuery.Where(city => city.Name.ToLower().Contains(filter.SearchKeyword.ToLower()));

        initialQuery = initialQuery.ApplyPagination(filter);

        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
    }
}