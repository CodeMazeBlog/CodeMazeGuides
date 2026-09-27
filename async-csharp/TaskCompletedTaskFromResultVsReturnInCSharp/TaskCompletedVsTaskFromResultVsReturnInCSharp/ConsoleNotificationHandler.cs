namespace TaskCompletedVsTaskFromResultVsReturnInCSharp;

public class ConsoleNotificationHandler : INotificationHandler
{
    public Task HandleAsync(string message)
    {
        Console.WriteLine(message);

        return Task.CompletedTask;
    }
}