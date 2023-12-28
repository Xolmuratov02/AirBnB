namespace AirBnB.Infrastructure.StorageFiles.Settings;

public class StorageFileSettings
{
    public IEnumerable<StorageFileLocationSettings> LocationSettings { get; init; } = default!;
}