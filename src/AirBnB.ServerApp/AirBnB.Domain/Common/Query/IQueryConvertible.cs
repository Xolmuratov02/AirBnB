namespace AirBnB.Domain.Common.Query;

public interface IQueryConvertible<TSource>
{
    QuerySpecification<TSource> ToQuerySpecification(bool asNoTracking = false);
}