namespace Shop.Shared;

public interface IEventBus
{
    ValueTask PublishAsync<TEvent>(TEvent integrationEvent, CancellationToken cancellationToken = default)
        where TEvent : notnull;
}

public interface IIntegrationEventHandler<in TEvent>
{
    Task HandleAsync(TEvent integrationEvent, CancellationToken cancellationToken = default);
}
