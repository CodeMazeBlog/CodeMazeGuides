using Rebus.Activation;
using Rebus.Config;
using Rebus.Retry.Simple;
using Shared;
using Subscriber;

using var activator = new BuiltinHandlerActivator();

activator.Register(() => new UserCreatedEventHandler(activator.Bus));

// configure subscriber
var subscriber = Configure.With(activator)
    .Transport(t => t.UseRabbitMq("amqp://guest:guest@localhost:5672", "user-created"))
    .Options(o => o.EnableFleetManager("https://api.rebus.fm", "<API_KEY>"))
    .Start();

await subscriber.Subscribe<UserCreatedEvent>();

Console.ReadLine();

