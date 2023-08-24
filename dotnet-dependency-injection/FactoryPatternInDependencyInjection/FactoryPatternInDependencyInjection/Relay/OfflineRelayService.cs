namespace FactoryPatternInDependencyInjection.Relay;

public class OfflineRelayService : IRelayService
{
    public RelayMode RelayMode => RelayMode.Offline;

    public string Relay(string message) => $"Offline: {message}";
}