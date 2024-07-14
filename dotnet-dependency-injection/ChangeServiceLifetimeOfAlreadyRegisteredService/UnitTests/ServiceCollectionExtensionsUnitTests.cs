using ChangeServiceLifetimeOfAlreadyRegisteredService;
using ChangeServiceLifetimeOfAlreadyRegisteredService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests;

public class ServiceCollectionExtensionsUnitTests
{

    [Fact]
    public void GivenServiceIsScoped_WhenReplaceWithSingletonAndAnotherImplementation_ThenServiceIsSingletonWithAnotherImplementation()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddScoped<IService, DefaultService>();

        // Act
        services.ReplaceWithSingleton<IService, LocalDevelopmentService>();

        // Assert
        var serviceDescriptor = services.SingleOrDefault(sd => sd.ServiceType == typeof(IService));
        Assert.NotNull(serviceDescriptor);
        Assert.Equal(ServiceLifetime.Singleton, serviceDescriptor.Lifetime);
        Assert.Equal(typeof(LocalDevelopmentService), serviceDescriptor.ImplementationType);
    }

    [Fact]
    public void GivenServiceIsScoped_WhenReplaceWithSingletonUsingImplementation_ThenServiceIsSingleton()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddScoped<DefaultService>();

        // Act
        services.ReplaceWithSingleton<DefaultService>();

        // Assert
        var serviceDescriptor = services.SingleOrDefault(sd => sd.ServiceType == typeof(DefaultService));
        Assert.NotNull(serviceDescriptor);
        Assert.Equal(ServiceLifetime.Singleton, serviceDescriptor.Lifetime);
        Assert.Equal(typeof(DefaultService), serviceDescriptor.ImplementationType);
    }

    [Fact]
    public void GivenServiceIsSingleton_WhenReplaceWithScopedAndAnotherImplementation_ThenServiceIsScopedWithAnotherImplementation()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddSingleton<IService, DefaultService>();

        // Act
        services.ReplaceWithScoped<IService, LocalDevelopmentService>();

        // Assert
        var serviceDescriptor = services.SingleOrDefault(sd => sd.ServiceType == typeof(IService));
        Assert.NotNull(serviceDescriptor);
        Assert.Equal(ServiceLifetime.Scoped, serviceDescriptor.Lifetime);
        Assert.Equal(typeof(LocalDevelopmentService), serviceDescriptor.ImplementationType);
    }

    [Fact]
    public void GivenServiceIsSingleton_WhenReplaceWithScopedUsingImplementation_ThenServiceIsScoped()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddSingleton<DefaultService>();

        // Act
        services.ReplaceWithScoped<DefaultService>();

        // Assert
        var serviceDescriptor = services.SingleOrDefault(sd => sd.ServiceType == typeof(DefaultService));
        Assert.NotNull(serviceDescriptor);
        Assert.Equal(ServiceLifetime.Scoped, serviceDescriptor.Lifetime);
        Assert.Equal(typeof(DefaultService), serviceDescriptor.ImplementationType);
    }

    [Fact]
    public void GivenServiceIsSingleton_WhenReplaceWithTransientAndAnotherImplementation_ThenServiceIsTransientWithAnotherImplementation()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddSingleton<IService, DefaultService>();

        // Act
        services.ReplaceWithTransient<IService, LocalDevelopmentService>();

        // Assert
        var serviceDescriptor = services.SingleOrDefault(sd => sd.ServiceType == typeof(IService));
        Assert.NotNull(serviceDescriptor);
        Assert.Equal(ServiceLifetime.Transient, serviceDescriptor.Lifetime);
        Assert.Equal(typeof(LocalDevelopmentService), serviceDescriptor.ImplementationType);
    }

    [Fact]
    public void GivenServiceIsSingleton_WhenReplaceWithTransientUsingImplementation_ThenServiceIsTransient()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddSingleton<DefaultService>();

        // Act
        services.ReplaceWithTransient<DefaultService>();

        // Assert
        var serviceDescriptor = services.SingleOrDefault(sd => sd.ServiceType == typeof(DefaultService));
        Assert.NotNull(serviceDescriptor);
        Assert.Equal(ServiceLifetime.Transient, serviceDescriptor.Lifetime);
        Assert.Equal(typeof(DefaultService), serviceDescriptor.ImplementationType);
    }
}