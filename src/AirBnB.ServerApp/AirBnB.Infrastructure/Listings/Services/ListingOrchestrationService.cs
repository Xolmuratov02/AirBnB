using AirBnB.Application.Listings.Models;
using AirBnB.Application.Listings.Services;
using AirBnB.Application.Listings;

namespace AirBnB.Infrastructure.Listings.Services;

public class ListingOrchestrationService(IListingService listingService) : IListingOrchestrationService
{
    public async ValueTask<IList<ListingAnalysisDetails>> GetByAvailabilityAsync(
        ListingAvailabilityFilter listingAvailabilityFilter,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        var listingQuerySpecification = listingAvailabilityFilter.ToQuerySpecification(asNoTracking);
        var result = await listingService.GetAsync(listingQuerySpecification, cancellationToken);
        return result.Select(
                listing => new ListingAnalysisDetails
                {
                    Listing = listing
                }
            )
            .ToList();
    }
}