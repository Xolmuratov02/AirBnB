using AirBnB.Domain.Common.Entities;
using AirBnB.Domain.Enums;

namespace AirBnB.Domain.Entities;

public class StorageFile : Entity
{
    public string FileName { get; set; } = default!;

    public StorageFileType Type { get; set; }
}