namespace ConditionalDependencyResolution.Alert;

public interface IAlertService
{
    AlertMode Mode { get; }

    string Send(string message);
}