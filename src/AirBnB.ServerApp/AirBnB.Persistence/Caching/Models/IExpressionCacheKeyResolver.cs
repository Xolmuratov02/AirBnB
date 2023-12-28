using System.Linq.Expressions;

namespace AirBnB.Persistence.Caching.Models;

public interface IExpressionCacheKeyResolver
{
    string GetCacheKey<TResult>(Expression expression, Type? actualType = default);
}