namespace ConditionalDependencyResolution.Tests;

public abstract class BaseUnitTest
{
    protected readonly IServiceProvider _serviceProvider;

    public BaseUnitTest()
    {
        _serviceProvider = Helper.CreateServiceProvider();
    }
}