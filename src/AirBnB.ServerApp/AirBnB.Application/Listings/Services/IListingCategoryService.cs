using AirBnB.Application.Common.Queries.Models;
using AirBnB.Application.Listings.Models;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Listings.Services;

public interface IListingCategoryService
{
    ValueTask<IList<ListingCategory>> GetAsync(
        ListingCategoryFilter listingCategoryFilter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    );
}