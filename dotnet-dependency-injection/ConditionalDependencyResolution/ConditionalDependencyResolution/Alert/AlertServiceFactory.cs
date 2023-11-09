namespace ConditionalDependencyResolution.Alert;

public class AlertServiceFactory : IAlertServiceFactory
{
    private readonly IEnumerable<IAlertService> _alertServices;

    public AlertServiceFactory(IEnumerable<IAlertService> alertServices)
    {
        _alertServices = alertServices;
    }

    public IAlertService GetAlertService(AlertMode mode)
    {
        return _alertServices.FirstOrDefault(e => e.Mode == mode)!;
    }
}