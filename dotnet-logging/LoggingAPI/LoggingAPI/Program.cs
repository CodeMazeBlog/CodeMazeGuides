using LoggingAPI;
using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});

ILogger<Student> logger = loggerFactory.CreateLogger<Student>();
var student = new Student("John", "IT", logger);

var department = new Department("IT", "Information Technology", loggerFactory);
