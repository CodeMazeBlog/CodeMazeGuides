namespace AutomaticRegistrationOfMinimalAPIs.Contracts.Teacher;

public class TeacherDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Subject { get; set; }
}
