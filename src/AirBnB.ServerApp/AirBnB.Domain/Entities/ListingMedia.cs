using AirBnB.Domain.Common.Entities;

namespace AirBnB.Domain.Entities;

public class ListingMedia : Entity
{
    public Guid ListingId { get; set; }

    public Guid StorageFileId { get; set; }

    public Listing Listing { get; set; } = default!;

    public StorageFile StorageFile { get; set; } = default!;
}