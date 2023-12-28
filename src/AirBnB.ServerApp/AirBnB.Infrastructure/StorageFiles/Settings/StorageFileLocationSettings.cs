using AirBnB.Domain.Enums;

namespace AirBnB.Infrastructure.StorageFiles.Settings;

public class StorageFileLocationSettings
{
    public StorageFileType StorageFileType { get; init; }

    public string FolderPath { get; init; } = default!;
}