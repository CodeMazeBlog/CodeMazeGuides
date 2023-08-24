namespace ConditionalDependencyResolution.Alert;

public class EmailAlertService : IAlertService
{
    public AlertMode Mode => AlertMode.Email;

    public string Send(string message) => $"Email: {message}"; 
}