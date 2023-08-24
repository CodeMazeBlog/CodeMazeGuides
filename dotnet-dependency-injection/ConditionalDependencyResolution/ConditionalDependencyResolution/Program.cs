using ConditionalDependencyResolution.Message;

var serviceProvider = Helper.CreateServiceProvider();

serviceProvider.GetService<IMessageService>()!
    .Send("A sample message.");

Console.ReadLine();