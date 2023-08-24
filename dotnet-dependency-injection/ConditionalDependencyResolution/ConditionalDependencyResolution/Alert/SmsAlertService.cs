namespace ConditionalDependencyResolution.Alert;

public class SmsAlertService : IAlertService
{
    public AlertMode Mode => AlertMode.Sms;

    public string Send(string message) => $"Sms: {message}";
}