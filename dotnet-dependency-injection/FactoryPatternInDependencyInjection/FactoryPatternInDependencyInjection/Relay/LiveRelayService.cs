namespace FactoryPatternInDependencyInjection.Relay;

public class LiveRelayService : IRelayService
{
    public RelayMode RelayMode => RelayMode.Live;

    public string Relay(string message) => $"Live: {message}";
}