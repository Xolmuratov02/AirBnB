using AirBnB.Domain.Common.Entities;
using AirBnB.Domain.Enums;

namespace AirBnB.Domain.Entities;

public abstract class Location : Entity
{
    public string Name { get; set; } = default!;

    public LocationType Type { get; set; }
}