using FactoryPatternInDependencyInjection.LabelGen;

namespace FactoryPatternInDependencyInjection.Tests;

public class LabelGenServiceFactoryUnitTests : BaseUnitTest
{
    [Fact]
    public void GivenServiceWithConstructorParameters_WhenInjectedByFactoryDelegate_ThenResolvedSuccessfully()
    {
        var service = _serviceProvider.GetService<LabelGenService>()!;

        var label = service.Generate();

        Assert.StartsWith("CD", label);
        Assert.EndsWith("MZ", label);
    }

    [Fact]
    public void GivenServiceWithConstructorParameters_WhenInjectedByWrapperFactory_ThenResolvedSuccessfully()
    {
        var service = _serviceProvider.GetService<LabelGenServiceFactory>()!
            .GetLabelGenService();

        var label = service.Generate();

        Assert.StartsWith("CD", label);
        Assert.EndsWith("MZ", label);
    }
}