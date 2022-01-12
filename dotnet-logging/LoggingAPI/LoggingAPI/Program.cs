using Microsoft.Extensions.Logging;

namespace LoggingAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            ILogger<Student> logger = loggerFactory.CreateLogger<Student>();
            Student student = new Student("Raghu", "IT", logger);

            Department department = new Department("IT", "Information Technology", loggerFactory);

        }
    }
}