using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;

namespace AirBnB.Persistence.Repositories.Interfaces;

public interface IListingCategoryRepository
{
    ValueTask<IList<ListingCategory>> GetAsync(QuerySpecification<ListingCategory> querySpecification, CancellationToken cancellationToken = default);
}