namespace AutomapperVsMapster.NestedTypeMapping;
public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public AddressDto Address { get; set; } = null!;
}