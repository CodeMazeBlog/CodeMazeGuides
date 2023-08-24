namespace FactoryPatternInDependencyInjection.Relay;

public class SandboxRelayService : IRelayService
{
    public RelayMode RelayMode => RelayMode.Sandbox;

    public string Relay(string message) => $"Sandbox: {message}";    
}