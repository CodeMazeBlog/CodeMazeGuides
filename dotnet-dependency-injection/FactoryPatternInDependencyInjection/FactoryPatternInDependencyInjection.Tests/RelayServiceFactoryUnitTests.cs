using FactoryPatternInDependencyInjection.Relay;

namespace FactoryPatternInDependencyInjection.Tests;

public class RelayServiceFactoryUnitTests : BaseUnitTest
{
    [Fact]
    public void GivenMultipleConcereteServices_WhenUsedWithFactory_ThenCanBeResolvedConditionally()
    {
        var factory = _serviceProvider.GetService<RelayServiceFactory>()!;

        var liveRelay = factory.GetRelayService(RelayMode.Live);
        var sandboxRelay = factory.GetRelayService(RelayMode.Sandbox);

        Assert.Equal("Live: Demo", liveRelay.Relay("Demo"));
        Assert.Equal("Sandbox: Demo", sandboxRelay.Relay("Demo"));
    }
}