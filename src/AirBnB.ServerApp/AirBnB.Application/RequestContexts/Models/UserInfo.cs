namespace AirBnB.Application.RequestContexts.Models;

public class UserInfo
{
    public UserCoordinates Coordinates { get; set; } = default!;

    public UserRegion Region { get; set; } = default!;
}