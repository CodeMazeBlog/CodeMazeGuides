using IntroductionToScrutorInDotNET.Decorators;
using IntroductionToScrutorInDotNET.Models;
using IntroductionToScrutorInDotNET.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Tests;

public class DecorateTests
{
    private IServiceCollection _services = new ServiceCollection();

    [Fact]
    public void WhenRegisteringDecorator_ThenDecoratorTypeIsResolved()
    {
        _services
            .AddScoped<IRepository<Customer>, CustomerRepository>()
            .Decorate<IRepository<Customer>, RepositoryLoggingDecorator<Customer>>();

        var serviceProvider = _services.BuildServiceProvider();

        var decoratedService = serviceProvider.GetService<IRepository<Customer>>();
        Assert.IsType<RepositoryLoggingDecorator<Customer>>(decoratedService);


        BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        FieldInfo? field = typeof(RepositoryLoggingDecorator<Customer>).GetField("_decoratedService", bindFlags);
        
        Assert.IsType<CustomerRepository>(field?.GetValue(decoratedService));
    }
}
