using AirBnB.Domain.Common.Entities;

namespace AirBnB.Domain.Entities;

public class ListingCategory : Entity
{
    public string Name { get; set; } = default!;

    public Guid ImageStorageFileId { get; set; }

    public StorageFile ImageStorageFile { get; set; } = default!;
}