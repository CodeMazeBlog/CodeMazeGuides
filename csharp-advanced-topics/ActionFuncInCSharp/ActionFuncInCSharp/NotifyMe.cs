namespace AsyncFuncInCSharp;

public static class NotifyMe
{
    public static string SendNotification(string message, DateTime notificationTime) => $"Process {message} at: {notificationTime}.";
}