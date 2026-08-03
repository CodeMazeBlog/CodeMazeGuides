using SimpleInjectorExample.Spec;

namespace SimpleInjectorExample.Services;

public class EmailNotification : INotification
{
    public void Notify(string notification)
    {
        Console.WriteLine($"[ Email Notification : {DateTime.Now} ] {notification}");
    }
}