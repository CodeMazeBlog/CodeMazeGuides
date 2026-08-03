using Rebus.Handlers;
using Shared;
using Rebus.Bus;
using Rebus.Exceptions;
using Rebus.Messages;
using Rebus.Retry.Simple;

namespace Subscriber;
public class UserCreatedEventHandler : 
    IHandleMessages<UserCreatedEvent>, 
    IHandleMessages<IFailed<UserCreatedEvent>>
{
    private readonly IBus _bus;
    private const int MaxRetries = 3;

    public UserCreatedEventHandler(IBus bus)
    {
        _bus = bus;
    }
    
    public async Task Handle(UserCreatedEvent message)
    {
        Console.WriteLine($"{nameof(UserCreatedEvent)} received. Username: {message.UserName}");
    }

    public async Task Handle(IFailed<UserCreatedEvent> message)
    {
        var deferCount = int.Parse(message.Headers.GetValueOrDefault(Headers.DeferCount) ?? "0");
        if (deferCount >= MaxRetries)
        {
            await _bus.Advanced.TransportMessage.Deadletter(
                $"Unable to handle {nameof(UserCreatedEvent)}, " +
                $"with error: {message.ErrorDescription}");
        }
        else
        {
            await _bus.Advanced.TransportMessage.Defer(TimeSpan.FromSeconds(10));
        }
    }
}
