namespace AutomaticRegistrationOfMinimalAPIs.Data.Models;

public class Teacher
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Subject { get; set; }
}
