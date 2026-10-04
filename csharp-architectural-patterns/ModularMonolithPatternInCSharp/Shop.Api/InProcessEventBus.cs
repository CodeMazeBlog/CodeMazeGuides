using System.Threading.Channels;
using Shop.Shared;

namespace Shop.Api;

public delegate Task EventDelivery(IServiceProvider services, CancellationToken cancellationToken);

public sealed class InProcessEventBus : IEventBus
{
    private readonly Channel<EventDelivery> _deliveries = Channel.CreateUnbounded<EventDelivery>();

    public ChannelReader<EventDelivery> Deliveries => _deliveries.Reader;

    public ValueTask PublishAsync<TEvent>(TEvent integrationEvent, CancellationToken cancellationToken = default)
        where TEvent : notnull =>
        _deliveries.Writer.WriteAsync(async (services, token) =>
        {
            foreach (var handler in services.GetServices<IIntegrationEventHandler<TEvent>>())
                await handler.HandleAsync(integrationEvent, token);
        }, cancellationToken);
}

public sealed class EventDispatcher(
    InProcessEventBus eventBus,
    IServiceScopeFactory scopeFactory,
    ILogger<EventDispatcher> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var delivery in eventBus.Deliveries.ReadAllAsync(stoppingToken))
        {
            using var scope = scopeFactory.CreateScope();

            try
            {
                await delivery(scope.ServiceProvider, stoppingToken);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "An integration event handler failed.");
            }
        }
    }
}
