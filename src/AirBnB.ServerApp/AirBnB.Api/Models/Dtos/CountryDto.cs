namespace AirBnB.Api.Models.Dtos;

public class CountryDto
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public string Code { get; init; } = default!;

    public ICollection<CityDto>? Cities { get; init; }
}