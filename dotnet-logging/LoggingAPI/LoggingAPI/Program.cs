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

            Log log = new Log(loggerFactory.CreateLogger<Log>());

            log.logInfo("I am a log message");
        }
    }
}