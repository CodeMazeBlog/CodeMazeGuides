using Rebus.Activation;
using Rebus.Config;
using Shared;
using Subscriber;

using var activator = new BuiltinHandlerActivator();

activator.Register(() => new UserCreatedEventHandler());

// configure subscriber
var subscriber = Configure.With(activator)
    .Transport(t => t.UseRabbitMq("amqp://guest:guest@localhost:5672", "user-created"))
    .Options(o => o.EnableFleetManager("https://api.rebus.fm", 
    "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJhaWQiOiJ0LXRlYW0yMi0xIiwidXBuIjoidXNlcjczNiIsIndoZW4iOiIxNjcwOTUxOTcyNDUyIn0.WNdYpNPiRr4_ATP10xTdXBjYPuGRW75QSO1rQXy3E85905kSSvFAFdukePB5NckliVRbbxlqNSmo9PA6k9pPwA"))
    .Start();

await subscriber.Subscribe<UserCreatedEvent>();

Console.ReadLine();

