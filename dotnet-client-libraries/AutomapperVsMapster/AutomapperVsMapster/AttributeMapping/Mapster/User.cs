using Mapster;

namespace AutomapperVsMapster.AttributeMapping.Mapster;

[AdaptTo(nameof(UserDto))]
[AdaptTwoWays(nameof(UserDto))]
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}