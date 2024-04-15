namespace ServerSentEventsForRealtimeUpdates.Server;

public interface ICounterService
{
    Task CountdownDelay();
    int GetStartValue();
}