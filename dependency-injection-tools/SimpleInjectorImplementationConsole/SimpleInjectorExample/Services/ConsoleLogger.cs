using SimpleInjectorExample.Spec;

namespace SimpleInjectorExample.Services;

public class ConsoleLogger : ILogger
{
    public void Information(string message)
    {
        Console.WriteLine($"[ Information: {DateTime.Now} ] {message}");
    }
}