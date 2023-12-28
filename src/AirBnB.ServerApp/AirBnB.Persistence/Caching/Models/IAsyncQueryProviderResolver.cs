using Microsoft.EntityFrameworkCore.Query;

namespace AirBnB.Persistence.Caching.Models;

public interface IAsyncQueryProviderResolver
{
    IAsyncQueryProvider Get();
}