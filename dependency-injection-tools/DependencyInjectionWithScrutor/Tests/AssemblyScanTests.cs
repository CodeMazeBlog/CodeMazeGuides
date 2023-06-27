using IntroductionToScrutorInDotNET.Models;
using IntroductionToScrutorInDotNET.Repositories;
using IntroductionToScrutorInDotNET.Services;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;

namespace Tests;

public class AssemblyScanTests
{
    private IServiceCollection _services = new ServiceCollection();

    [Fact]
    public void WhenRegisteringClassesFromNamespace_ThenAllServicesAreRegistered()
    {
        _services.Scan(scan => 
            scan.FromAssemblyOf<ICustomerService>()
                .AddClasses(classes => classes.InExactNamespaceOf<ICustomerService>())
                .AsImplementedInterfaces()
        );

        var serviceProvider = _services.BuildServiceProvider();

        Assert.NotNull(serviceProvider.GetService<ICustomerService>());
        Assert.NotNull(serviceProvider.GetService<IOrdersService>());
    }


    [Fact]
    public void WhenFilteringSelection_ThenOnlySelectedServicesAreRegistered()
    {
        _services.Scan(scan =>
            scan.FromAssemblyOf<ICustomerService>()
                .AddClasses(classes => classes
                    .AssignableTo<IOrdersService>()
                    .InNamespaces("IntroductionToScrutorInDotNET.Services"))
                .AsMatchingInterface()
        );

        var serviceProvider = _services.BuildServiceProvider();

        Assert.Null(serviceProvider.GetService<ICustomerService>());
        Assert.NotNull(serviceProvider.GetService<IOrdersService>());
    }

    [Fact]
    public void WhenRegisteringGenerics_ThenAllServicesAreRegistered()
    {
        _services.Scan(scan =>
            scan.FromAssemblyOf<ICustomerService>()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IRepository<>))
                    .InExactNamespaceOf<CustomerRepository>())
                .AsImplementedInterfaces()
        );

        var serviceProvider = _services.BuildServiceProvider();

        Assert.NotNull(serviceProvider.GetService<IRepository<Customer>>());
        Assert.NotNull(serviceProvider.GetService<IRepository<Order>>());
    }

    [Fact]
    public void WhenRegisteringServices_ThenCanSetNonDefaultLifetime()
    {
        _services.Scan(scan =>
            scan.FromAssemblyOf<ICustomerService>()
                .AddClasses(classes => classes.InExactNamespaceOf<ICustomerService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );

        var serviceDescriptor = _services.FirstOrDefault(x => x.ServiceType == typeof(ICustomerService));

        Assert.NotNull(serviceDescriptor);
        Assert.Equal(ServiceLifetime.Scoped, serviceDescriptor.Lifetime);
    }

    [Fact]
    public void WhenRegisteringServices_ThenCanSetRegistrationStrategy()
    {
        _services.Scan(scan =>
            scan.FromAssemblyOf<ICustomerService>()
                .AddClasses(classes => classes.InExactNamespaceOf<ICustomerService>())
                .UsingRegistrationStrategy(RegistrationStrategy.Append)
                .AsImplementedInterfaces()
        );

        var serviceProvider = _services.BuildServiceProvider();

        var services = serviceProvider.GetServices<ICustomerService>();
        Assert.Equal(2, services.Count());

        _services = new ServiceCollection();
        _services.Scan(scan =>
            scan.FromAssemblyOf<ICustomerService>()
                .AddClasses(classes => classes.InExactNamespaceOf<ICustomerService>())
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
        );

        serviceProvider = _services.BuildServiceProvider();

        services = serviceProvider.GetServices<ICustomerService>();
        Assert.Single(services);
    }

    [Fact]
    public void WhenRegisteringServices_ThenCanChainSelectors()
    {
        _services.Scan(scan =>
            scan.FromAssemblyOf<ICustomerService>()
                .AddClasses(classes => classes.InExactNamespaceOf<ICustomerService>())
                    .AsMatchingInterface()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.InExactNamespaceOf(typeof(IRepository<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
        );

        var serviceProvider = _services.BuildServiceProvider();

        Assert.NotNull(serviceProvider.GetService<ICustomerService>());
        Assert.NotNull(serviceProvider.GetService<IRepository<Customer>>());
    }
}