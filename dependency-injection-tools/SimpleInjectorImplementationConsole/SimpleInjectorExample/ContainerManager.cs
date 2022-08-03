using SimpleInjector;
using SimpleInjectorExample.Services;
using SimpleInjectorExample.Spec;

public class ContainerManager
{
    private static readonly Lazy<Container> _container = new Lazy<Container>(ConfigureServices);
    
    private static Container ConfigureServices()
    {
        var container = new Container();
        container.Register<ILogger, ConsoleLogger>();
        container.Register<IUserRepository>(() => new UserRepository());
        container.Register<IAddressRepository, AddressRepository>();
        container.Register<IUserService, UserService>();
        container.Collection.Register<INotification>(typeof(EmailNotification), typeof(SMSNotification));
        container.Verify();
        return container;
    }

    public static Container Instance { get => _container.Value; }
}