using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjectorExample.Services;
using SimpleInjectorExample.Spec;

public class ContainerManager
{
    private static readonly Lazy<Container> _container = new Lazy<Container>(ConfigureServices);
    
    private static Container ConfigureServices()
    {
        var container = new Container();
        container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        container.Register<ILogger, ConsoleLogger>(Lifestyle.Singleton);
        container.Register<IUserRepository>(() => new UserRepository());
        container.Register<IAddressRepository, AddressRepository>(Lifestyle.Scoped);
        container.Register<IUserService, UserService>();
        container.Collection.Register<INotification>(typeof(EmailNotification), typeof(SMSNotification));
        container.Verify();
        return container;
    }

    public static Container Instance { get => _container.Value; }
}