using AirBnB.Domain.Enums;

namespace AirBnB.Domain.Entities;

public class Country : Location
{
    public Country() => Type = LocationType.Country;

    public string Code { get; set; } = default!;

    public IList<City> Cities { get; set; } = new List<City>();
}