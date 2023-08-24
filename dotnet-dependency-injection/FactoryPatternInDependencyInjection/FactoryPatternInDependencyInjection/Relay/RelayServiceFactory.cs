namespace FactoryPatternInDependencyInjection.Relay;

public class RelayServiceFactory
{
    private readonly IEnumerable<IRelayService> _relayServices;

    public RelayServiceFactory(IEnumerable<IRelayService> relayServices)
    {
        _relayServices = relayServices;
    }

    public IRelayService GetRelayService(RelayMode relayMode)
    {
        return _relayServices.FirstOrDefault(e => e.RelayMode == relayMode)
            ?? throw new NotSupportedException();
    }
}