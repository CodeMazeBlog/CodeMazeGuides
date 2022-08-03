using SimpleInjectorExample.Spec;

static void RunLogger()
{
    var logger = ContainerManager.Instance.GetInstance<ILogger>();
    logger.Information("Hello SimpleInjector");
}

static void RunNotificationServices()
{
    string notification = "Simple Injector Ping";
    var notificationServices = ContainerManager.Instance.GetAllInstances<INotification>();
    foreach(var service in notificationServices)
    {
        service.Notify(notification);
    }    
}

RunLogger();
RunNotificationServices();