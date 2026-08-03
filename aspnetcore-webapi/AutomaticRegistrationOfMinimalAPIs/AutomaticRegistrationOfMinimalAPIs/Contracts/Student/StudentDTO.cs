namespace AutomaticRegistrationOfMinimalAPIs.Contracts.Student;

public class StudentDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int Age { get; set; }
}
