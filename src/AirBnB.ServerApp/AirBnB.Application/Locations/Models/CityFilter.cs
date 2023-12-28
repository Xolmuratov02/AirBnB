using AirBnB.Domain.Common.Query;

namespace AirBnB.Application.Locations.Models;

public class CityFilter : FilterPagination
{
    public string? SearchKeyword { get; init; }
}