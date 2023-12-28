namespace AirBnB.Application.RequestContexts.Models;

public class UserRegion
{
    public string? CityName { get; set; }

    public string? CountryName { get; set; }

    public string Language { get; set; } = default!;
}