using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Listings.Services;

public interface IListingService
{
    ValueTask<IList<Listing>> GetAsync(QuerySpecification<Listing> querySpecification, CancellationToken cancellationToken = default);
}