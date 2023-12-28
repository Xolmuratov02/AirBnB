using AirBnB.Application.Common.Queries.Models;
using AirBnB.Application.Listings.Models;
using AirBnB.Application.Listings.Services;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Repositories.Interfaces;

namespace AirBnB.Infrastructure.Listings.Services;

public class ListingCategoryService(IListingCategoryRepository listingCategoryRepository) : IListingCategoryService
{
    public async ValueTask<IList<ListingCategory>> GetAsync(
        ListingCategoryFilter listingCategoryFilter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    )
    {
        return await listingCategoryRepository
            .Get(asNoTracking: queryOptions.AsNoTracking)
            .ApplyPagination(listingCategoryFilter)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}