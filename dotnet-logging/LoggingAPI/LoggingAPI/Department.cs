using Microsoft.Extensions.Logging;

namespace LoggingAPI;

public class Department
{
    public string Name { get; set; }
    public string Description { get; set; }

    private readonly ILogger _logger;

    public Department(string name, string description, ILoggerFactory factory)
    {
        Name = name;
        Description = description;

        _logger = factory.CreateLogger<Department>();
        _logger.LogInformation("Department is {Name} {Description}", Name, Description);
    }
}
