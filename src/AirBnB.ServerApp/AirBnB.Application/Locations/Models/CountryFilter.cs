using AirBnB.Domain.Common.Query;

namespace AirBnB.Application.Locations.Models;

public class CountryFilter : FilterPagination
{
    public string? SearchKeyword { get; init; }

    public bool IncludeCities { get; set; }
}