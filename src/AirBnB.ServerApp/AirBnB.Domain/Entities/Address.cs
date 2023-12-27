using AirBnB.Domain.Common.Entities;

namespace AirBnB.Domain.Entities;

public class Address : Entity
{
    public string? City { get; set; }

    public Guid? CityId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}