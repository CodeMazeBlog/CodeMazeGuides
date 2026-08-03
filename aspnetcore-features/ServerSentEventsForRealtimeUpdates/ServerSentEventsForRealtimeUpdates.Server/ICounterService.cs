namespace ServerSentEventsForRealtimeUpdates.Server;

public interface ICounterService
{
    Task CountdownDelay(CancellationToken cancellationToken);
    int StartValue { get; }
}