namespace ConditionalDependencyResolution.Alert
{
    public interface IAlertServiceFactory
    {
        IAlertService GetAlertService(AlertMode mode);
    }
}