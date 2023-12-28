using AirBnB.Application.Listings.Models;

namespace AirBnB.Application.Listings.Services;

public interface IListingOrchestrationService
{
    ValueTask<IList<ListingAnalysisDetails>> GetByAvailabilityAsync(
        ListingAvailabilityFilter listingAvailabilityFilter,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
}