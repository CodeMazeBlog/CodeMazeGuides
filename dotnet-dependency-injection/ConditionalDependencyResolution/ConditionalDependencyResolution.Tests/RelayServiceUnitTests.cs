using ConditionalDependencyResolution.Relay;

namespace ConditionalDependencyResolution.Tests;

public class RelayServiceUnitTests : BaseUnitTest
{
    [Fact]
    public void GivenMultiVariants_WhenChosenByConfiguration_ThenCanBeResolvedPreEmptively()
    {
        var service = _serviceProvider.GetService<IRelayService>()!;
        
        Assert.Equal("Sandbox: Demo", service.Relay("Demo"));
    }
}