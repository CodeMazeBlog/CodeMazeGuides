namespace Tests;

public class ServiceCollectionTest
{
    private readonly IServiceCollection _serviceCollection = new ServiceCollection();
    private readonly IServiceProvider _serviceProvider;

    public ServiceCollectionTest()
    {
        _serviceCollection.AddDependencies();
        _serviceProvider = _serviceCollection.BuildServiceProvider();
    }

    [Theory]
    [InlineData(typeof(IPetService), typeof(PetService), ServiceLifetime.Singleton)]
    [InlineData(typeof(IWildAnimalService), typeof(WildAnimalService), ServiceLifetime.Transient)]
    [InlineData(typeof(IMarineAnimalsService), typeof(MarineAnimalsService), ServiceLifetime.Scoped)]
    public void GivenDependenciesExists_WhenServiceIsRegistered_ThenServiceIsRegistered(Type interfaceType, Type classType, ServiceLifetime serviceLifetime)
    {
        var serviceType = _serviceProvider.GetService(interfaceType);

        Assert.NotNull(serviceType);

        var serviceDescriptor = _serviceCollection.SingleOrDefault(
            d => d.ServiceType == interfaceType &&
                 d.ImplementationType == classType &&
                 d.Lifetime == serviceLifetime);

        Assert.NotNull(serviceDescriptor);
    }
}