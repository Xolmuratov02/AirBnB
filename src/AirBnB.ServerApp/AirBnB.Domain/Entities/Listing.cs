using AirBnB.Domain.Common.Entities;
using System.Net;

namespace AirBnB.Domain.Entities;

public class Listing : Entity
{
    public string Name { get; set; } = default!;

    public DateOnly BuiltDate { get; set; }

    public Address Address { get; set; } = default!;

    public Money PricePerNight { get; set; } = default!;

    public Guid CategoryId { get; set; }

    public ListingCategory Category { get; set; } = default!;

    public IList<ListingMedia> ImagesStorageFile { get; set; } = new List<ListingMedia>();
}