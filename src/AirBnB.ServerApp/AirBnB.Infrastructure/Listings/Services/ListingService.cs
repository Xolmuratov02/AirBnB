using AirBnB.Application.Listings.Services;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Repositories.Interfaces;

namespace AirBnB.Infrastructure.Listings.Services;

public class ListingService(IListingRepository listingRepository) : IListingService
{
    public ValueTask<IList<Listing>> GetAsync(QuerySpecification<Listing> querySpecification, CancellationToken cancellationToken = default)
    {
        return listingRepository.GetAsync(querySpecification, cancellationToken);
    }
}