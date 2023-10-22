namespace ActionAndFuncDelegates;

public class SendNotification
{
    public Action<string, string> SendNotificationAction = (recipient, message) =>
    {
        Console.WriteLine($"Sending a notification to {recipient}: {message}");
    };
}
