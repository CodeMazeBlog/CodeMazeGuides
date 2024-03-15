namespace AutomaticRegistrationOfMinimalAPIs.Data.Models;

public class Student
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int Age { get; set; }
}
