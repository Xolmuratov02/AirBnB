using AirBnB.Domain.Common.Query;

namespace AirBnB.Application.Listings.Models;

public class ListingCategoryFilter : FilterPagination
{
    public ListingCategoryFilter()
    {
        // Set pagination to max values
        PageSize = int.MaxValue;
        PageToken = 1;
    }
}