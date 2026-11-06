using Microsoft.Extensions.Logging;

namespace LoggingAPI;

public class Student
{
    public string Name { get; set; }
    public string Department { get; set; }

    private readonly ILogger _logger;

    public Student(string name, string department, ILogger<Student> logger)
    {
        Name = name;
        Department = department;
        _logger = logger;

        _logger.LogInformation("Name of student is {Name} and his department is {Department}", Name, Department);
    }
}
