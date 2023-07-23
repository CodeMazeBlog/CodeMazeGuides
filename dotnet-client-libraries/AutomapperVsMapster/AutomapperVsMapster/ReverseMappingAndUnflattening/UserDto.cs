namespace AutomapperVsMapster.ReverseMappingAndUnflattening;
public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string AddressAddressLine1 { get; set; } = null!;
    public string AddressAddressLine2 { get; set; } = null!;
    public string AddressCity { get; set; } = null!;
    public string AddressState { get; set; } = null!;
    public string AddressCountry { get; set; } = null!;
    public string AddressZipCode { get; set; } = null!;
}