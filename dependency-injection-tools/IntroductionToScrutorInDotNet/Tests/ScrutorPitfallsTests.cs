using IntroductionToScrutorInDotNet.Entities;
using IntroductionToScrutorInDotNet.Repositories;
using IntroductionToScrutorInDotNet.Repositories.Decorators;
using IntroductionToScrutorInDotNet.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Tests;

public class ScrutorPitfallsTests
{
    private static ServiceCollection ScanRepositories(RegistrationStrategy? strategy = null)
    {
        var services = new ServiceCollection();
        services.Scan(selector => selector
            .FromAssembliesOf(typeof(UserRepository))
            .AddClasses(classSelector => classSelector.AssignableTo(typeof(IRepository<>)))
            .UsingRegistrationStrategy(strategy ?? RegistrationStrategy.Append)
            .AsImplementedInterfaces());
        return services;
    }

    [Fact]
    public void GivenTwoScans_WhenAppending_ThenRegistrationIsDuplicated()
    {
        var services = ScanRepositories();
        services.Scan(selector => selector
            .FromAssembliesOf(typeof(UserRepository))
            .AddClasses(classSelector => classSelector.AssignableTo(typeof(IRepository<>)))
            .AsImplementedInterfaces());

        var count = services.Count(descriptor => descriptor.ServiceType == typeof(IRepository<User>));

        Assert.Equal(2, count);
    }

    [Fact]
    public void GivenTwoScans_WhenUsingSkipStrategy_ThenRegistrationIsNotDuplicated()
    {
        var services = ScanRepositories(RegistrationStrategy.Skip);
        services.Scan(selector => selector
            .FromAssembliesOf(typeof(UserRepository))
            .AddClasses(classSelector => classSelector.AssignableTo(typeof(IRepository<>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces());

        var count = services.Count(descriptor => descriptor.ServiceType == typeof(IRepository<User>));

        Assert.Equal(1, count);
    }

    [Fact]
    public void GivenScannedRegistration_WhenLifetimeIsNotSpecified_ThenItIsTransient()
    {
        var services = ScanRepositories();

        var descriptor = services.First(d => d.ServiceType == typeof(IRepository<User>));

        Assert.Equal(ServiceLifetime.Transient, descriptor.Lifetime);
    }

    [Fact]
    public void GivenNoPriorRegistration_WhenDecorating_ThenDecorationExceptionIsThrown()
    {
        var services = new ServiceCollection();

        var exception = Assert.Throws<DecorationException>(() =>
            services.Decorate<IRepository<User>, RepositoryLoggerDecorator<User>>());

        Assert.Contains("Could not find any registered services", exception.Message);
    }

    [Fact]
    public void GivenScannedRepository_WhenDecoratingTheOpenGeneric_ThenTheDecoratorResolves()
    {
        var services = ScanRepositories();

        services.Decorate(typeof(IRepository<>), typeof(RepositoryLoggerDecorator<>));

        var provider = services.BuildServiceProvider();
        var resolved = provider.GetRequiredService<IRepository<User>>();

        Assert.IsType<RepositoryLoggerDecorator<User>>(resolved);
    }
}
