namespace Tests;

public class ServiceCollectionTest
{
    private readonly ServiceCollection ServiceCollection;
    private readonly ServiceProvider ServiceProvider;

    public ServiceCollectionTest()
    {
        ServiceCollection = new ServiceCollection();

        ServiceCollection.AddDependencies();

        ServiceProvider = ServiceCollection.BuildServiceProvider();
    }

    [Fact]
    public void GivenDependenciesExists_WhenIPetServiceIsRegisteredAsSingleton_ThenServiceIsRegistered()
    {
        var petService = ServiceProvider.GetService<IAnimalService>();

        Assert.NotNull(petService);

        Assert.Single(ServiceCollection, x =>
        x.ServiceType == typeof(IAnimalService) &&
        x.ImplementationType == typeof(PetService) &&
        x.Lifetime == ServiceLifetime.Singleton);
    }

    [Fact]
    public void GivenDependenciesExists_WhenWildAnimalServicesIsCalled_ThenServiceNotRegistered()
    {
        var petService = ServiceProvider.GetService<IAnimalService>();

        Assert.NotNull(petService);

        Assert.Empty(ServiceCollection.Where(x =>
        x.ServiceType == typeof(IAnimalService) &&
        x.ImplementationType == typeof(WildAnimalServices)));
    }
}