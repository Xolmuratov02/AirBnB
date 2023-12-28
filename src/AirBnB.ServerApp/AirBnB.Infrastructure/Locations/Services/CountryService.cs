using AirBnB.Application.Common.Queries.Models;
using AirBnB.Application.Locations.Models;
using AirBnB.Application.Locations.Services;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Extensions;
using AirBnB.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Infrastructure.Locations.Services;

public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    public async ValueTask<IList<Country>> GetAsync(
        CountryFilter filter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    )
    {
        var initialQuery = countryRepository.Get(asNoTracking: queryOptions.AsNoTracking);

        if (filter.IncludeCities)
            initialQuery.Include(country => country.Cities);

        if (filter.SearchKeyword is not null)
            initialQuery = initialQuery.Where(country => country.Name.ToLower().Contains(filter.SearchKeyword.ToLower()));

        initialQuery = initialQuery.ApplyPagination(filter);

        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
    }
}