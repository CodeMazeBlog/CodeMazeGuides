namespace AutomapperVsMapster.Flattened;
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public string GetFullName() => $"{FirstName} {LastName}";
}