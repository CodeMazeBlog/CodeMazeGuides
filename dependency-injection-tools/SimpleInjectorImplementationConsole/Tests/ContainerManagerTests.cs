using SimpleInjectorExample.Services;
using SimpleInjectorExample.Spec;

using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Tests;

public class ContainerManagerTests
{
    [Fact]
    public void GivenINotification_WhenGetAllInstancesIsInvoked_ThenReturnsNotificationServices()
    {
        var expectedNumberOfServices = 2; 
        var services = ContainerManager.Instance.GetAllInstances<INotification>();
        var emailNotificationService = services.FirstOrDefault(service => service.GetType() == typeof(EmailNotification));
        var smsNotificationService  = services.FirstOrDefault(service => service.GetType() == typeof(SMSNotification));

        Assert.Equal(expectedNumberOfServices,services.Count());
        Assert.NotNull(emailNotificationService);
        Assert.NotNull(smsNotificationService);
    }

    [Fact]
    public void GivenILogger_WhenGetInstanceIsInvoked_ThenReturnsConsoleLogger()
    {
        var expectedType = typeof(ConsoleLogger);
        var service = ContainerManager.Instance.GetInstance<ILogger>();

        Assert.NotNull(service);
        Assert.Equal(expectedType,service.GetType());   
    }

    [Fact]
    public void GivenIUserRepository_WhenGetInstanceIsInvoked_ThenReturnsUserRepository()
    {
        var expectedType = typeof(UserRepository);
        var service = ContainerManager.Instance.GetInstance<IUserRepository>();

        Assert.NotNull(service);
        Assert.Equal(expectedType,service.GetType());
    }    

    [Fact]
    public void GivenIAddressRepository_WhenGetInstanceIsInvoked_ThenReturnsAddressRepository()
    {
        var expectedType = typeof(AddressRepository);

        using var scope = AsyncScopedLifestyle.BeginScope(ContainerManager.Instance);
        var service = ContainerManager.Instance.GetInstance<IAddressRepository>();

        Assert.NotNull(service);
        Assert.Equal(expectedType,service.GetType());
    }

    [Fact]
    public void GivenIUserService_WhenGetInstanceIsInvoked_ThenReturnsUserService()
    {
        var expectedType = typeof(UserService);
        
        using var scope = AsyncScopedLifestyle.BeginScope(ContainerManager.Instance);
        var service = ContainerManager.Instance.GetInstance<IUserService>();

        Assert.NotNull(service);
        Assert.Equal(expectedType,service.GetType());
    }

    [Fact]
    public void GivenSingletonDependingOnScoped_WhenVerifyIsInvoked_ThenThrowsLifestyleMismatch()
    {
        var container = new Container();
        container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        container.Register<IUserRepository, UserRepository>(Lifestyle.Singleton);
        container.Register<IAddressRepository, AddressRepository>(Lifestyle.Scoped);
        container.Register<IUserService, UserService>(Lifestyle.Singleton);

        var exception = Assert.Throws<DiagnosticVerificationException>(() => container.Verify());

        Assert.Contains("[Lifestyle Mismatch]", exception.Message);
    }

}
