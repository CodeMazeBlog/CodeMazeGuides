namespace AutomapperVsMapster.Flattened;
public class UserDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string AddressAddressLine1 { get; set; } = null!;
    public string AddressAddressLine2 { get; set; } = null!;
    public string AddressCity { get; set; } = null!;
    public string AddressState { get; set; } = null!;
    public string AddressCountry { get; set; } = null!;
    public string AddressZipCode { get; set; } = null!;
}