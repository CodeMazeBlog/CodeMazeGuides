namespace TaskCompletedVsTaskFromResultVsReturnInCSharp;

public interface INotificationHandler
{
    Task HandleAsync(string message);
}