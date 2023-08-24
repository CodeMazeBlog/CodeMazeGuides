namespace FactoryPatternInDependencyInjection.Relay;

public interface IRelayService
{
    string Relay(string message);

    RelayMode RelayMode { get; }
}