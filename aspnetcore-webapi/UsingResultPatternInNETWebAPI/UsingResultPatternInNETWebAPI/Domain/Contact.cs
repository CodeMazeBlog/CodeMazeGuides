namespace UsingResultPatternInNETWebAPI.Domain;

public class Contact
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Email { get; set; } = string.Empty;
}