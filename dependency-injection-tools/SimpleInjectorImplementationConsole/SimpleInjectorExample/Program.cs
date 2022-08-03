using SimpleInjector.Lifestyles;
using SimpleInjectorExample.Spec;

static void RunLogger()
{
    var logger = ContainerManager.Instance.GetInstance<ILogger>();
    logger.Information("Hello SimpleInjector");
}

static void RunNotificationServices(string notification)
{
    var notificationServices = ContainerManager.Instance.GetAllInstances<INotification>();
    foreach(var service in notificationServices)
    {
        service.Notify(notification);
    }    
}

static void PingUser(int userId)
{
    using var scope = AsyncScopedLifestyle.BeginScope(ContainerManager.Instance);
    var service = ContainerManager.Instance.GetInstance<IUserService>();
    var logger = ContainerManager.Instance.GetInstance<ILogger>();
    
    var detail = service.GetUserDetail(userId);
    logger.Information($"PINGING USER Name: {detail.User.FirstName} {detail.User.LastName}, Address: {detail.Address.City} - {detail.Address.Zone}");
    RunNotificationServices($"Hello {detail.User.FirstName} {detail.User.LastName}");
}

PingUser(1);
RunLogger();