using SimpleInjectorExample.Spec;

namespace SimpleInjectorExample.Services;

public class SMSNotification : INotification
{
    public void Notify(string notification)
    {
        Console.WriteLine($"[ SMS Notification : {DateTime.Now} ] {notification}");
    }
}
