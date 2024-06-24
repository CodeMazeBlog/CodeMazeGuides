namespace Tests;

public class ServiceCollectionTest
{
    private readonly IServiceCollection _serviceCollection;
    private readonly IServiceProvider _serviceProvider;

    public ServiceCollectionTest()
    {
        _serviceCollection = new ServiceCollection();
        _serviceCollection.AddDependencies();
        _serviceProvider = _serviceCollection.BuildServiceProvider();
    }

    [Fact]
    public void GivenDependenciesExists_WhenPetServiceIsRegisteredAsSingleton_ThenServiceIsRegistered()
    {
        var petService = _serviceProvider.GetService<IPetService>();

        Assert.NotNull(petService);

        var serviceDescriptor = _serviceCollection.SingleOrDefault(
            d => d.ServiceType == typeof(IPetService) &&
                 d.ImplementationType == typeof(PetService) &&
                 d.Lifetime == ServiceLifetime.Singleton);

        Assert.NotNull(serviceDescriptor);
    }

    [Fact]
    public void GivenDependenciesExists_WhenWildAnimalServiceIsRegisteredAsTransient_ThenServiceIsRegistered()
    {
        var wildAnimalService = _serviceProvider.GetService<IWildAnimalService>();

        Assert.NotNull(wildAnimalService);

        var serviceDescriptor = _serviceCollection.SingleOrDefault(
            d => d.ServiceType == typeof(IWildAnimalService) &&
                 d.ImplementationType == typeof(WildAnimalService) &&
                 d.Lifetime == ServiceLifetime.Transient);

        Assert.NotNull(serviceDescriptor);
    }

    [Fact]
    public void GivenDependenciesExists_WhenMarineAnimalsServiceIsRegisteredAsScoped_ThenServiceIsRegistered()
    {
        var marineAnimalsService = _serviceProvider.GetService<IMarineAnimalsService>();

        var serviceDescriptor = _serviceCollection.SingleOrDefault(
            d => d.ServiceType == typeof(IMarineAnimalsService) &&
                 d.ImplementationType == typeof(MarineAnimalsService) &&
                 d.Lifetime == ServiceLifetime.Scoped);

        Assert.NotNull(serviceDescriptor);
    }
}