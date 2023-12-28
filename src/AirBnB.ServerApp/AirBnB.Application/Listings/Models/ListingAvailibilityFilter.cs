using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Listings;

public class ListingAvailabilityFilter : FilterPagination, IQueryConvertible<Listing>
{
    public DateOnly StartDate { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public QuerySpecification<Listing> ToQuerySpecification(bool asNoTracking = false)
    {
        return new QuerySpecification<Listing>(PageSize, PageToken, asNoTracking);
    }

    public override bool Equals(object? obj)
    {
        return obj is ListingAvailabilityFilter listingAvailabilityFilter && listingAvailabilityFilter.GetHashCode() == GetHashCode();
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);
        hashCode.Add(StartDate);

        return hashCode.ToHashCode();
    }
}