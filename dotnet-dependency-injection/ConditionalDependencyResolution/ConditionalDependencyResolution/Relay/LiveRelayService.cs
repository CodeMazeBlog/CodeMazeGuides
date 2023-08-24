namespace ConditionalDependencyResolution.Relay;

public class LiveRelayService : IRelayService
{
    public string Relay(string message) => $"Live: {message}";
}