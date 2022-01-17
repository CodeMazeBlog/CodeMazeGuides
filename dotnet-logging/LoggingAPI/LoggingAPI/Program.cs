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
            var student = new Student("John", "IT", logger);

            var department = new Department("IT", "Information Technology", loggerFactory);

        }
    }
}