namespace AirBnB.Api.Models.Dtos;

public class CityDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public CountryDto? Country { get; set; } = default!;
}