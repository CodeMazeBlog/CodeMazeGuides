namespace ConditionalDependencyResolution.Relay;

public class SandboxRelayService : IRelayService
{
    public string Relay(string message) => $"Sandbox: {message}";    
}