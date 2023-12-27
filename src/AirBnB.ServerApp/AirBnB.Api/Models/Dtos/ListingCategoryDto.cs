namespace AirBnB.Api.Models.Dtos;

public class ListingCategoryDto
{
    public Guid Id { get; set; }

    public string Name { get; init; } = default!;

    public string ImageUrl { get; init; } = default!;
}