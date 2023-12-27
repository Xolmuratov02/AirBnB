using AirBnB.Domain.Enums;

namespace AirBnB.Domain.Entities;

public class City : Location
{
    public City() => Type = LocationType.City;

    public Guid? ParentId { get; set; }
}