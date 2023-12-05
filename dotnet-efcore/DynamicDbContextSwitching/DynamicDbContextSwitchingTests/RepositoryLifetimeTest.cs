using DynamicDbContextSwitching;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicDbContextSwitchingTests;

public class RepositoryLifetimeTest
{
    [Test]
    public void GivenARepositoryFactory_WhenNotRequestingANewOne_ThenReturnTheSameRepositoryInstancesOnMultipleCalls()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<PrimaryDbContext>(_ => new PrimaryDbContext(new()));
        serviceCollection.AddTransient<IRepository, PrimaryRepository>();
        serviceCollection.AddTransient<IRepositoryFactory, RepositoryFactory>();
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        var repositoryFactory = serviceProvider.GetRequiredService<IRepositoryFactory>();
        var primaryRepository1 = repositoryFactory.GetRepository<PrimaryRepository>();
        var primaryRepository2 = repositoryFactory.GetRepository<PrimaryRepository>();
        
        Assert.That(primaryRepository2, Is.SameAs(primaryRepository1));
    }
    
    [Test]
    public void GivenATransientRepositoryFactory_WhenRequestingANewOneAndRepositoryIsTransient_ThenReturnDifferentRepositoryInstancesOnMultipleCalls()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<PrimaryDbContext>(_ => new PrimaryDbContext(new()));
        serviceCollection.AddTransient<IRepository, PrimaryRepository>();
        serviceCollection.AddTransient<IRepositoryFactory, RepositoryFactory>();
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        var repositoryFactory = serviceProvider.GetRequiredService<IRepositoryFactory>();
        var primaryRepository1 = repositoryFactory.GetRepository<PrimaryRepository>();
        var repositoryFactory2 = serviceProvider.GetRequiredService<IRepositoryFactory>();
        var primaryRepository2 = repositoryFactory2.GetRepository<PrimaryRepository>();
        
        Assert.That(primaryRepository2, Is.Not.SameAs(primaryRepository1));
    }
    
    [Test]
    public void GivenASingletonRepositoryFactory_WhenRequestingANewOneAndRepositoryIsTransient_ThenReturnTheSameRepositoryInstancesOnMultipleCalls()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<PrimaryDbContext>(_ => new PrimaryDbContext(new()));
        serviceCollection.AddTransient<IRepository, PrimaryRepository>();
        serviceCollection.AddSingleton<IRepositoryFactory, RepositoryFactory>();
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        var repositoryFactory = serviceProvider.GetRequiredService<IRepositoryFactory>();
        var primaryRepository1 = repositoryFactory.GetRepository<PrimaryRepository>();
        var repositoryFactory2 = serviceProvider.GetRequiredService<IRepositoryFactory>();
        var primaryRepository2 = repositoryFactory2.GetRepository<PrimaryRepository>();
        
        Assert.That(primaryRepository2, Is.SameAs(primaryRepository1));
    }
}