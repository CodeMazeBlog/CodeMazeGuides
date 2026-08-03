namespace ServerSentEventsForRealtimeUpdates.Server;

public class CounterService : ICounterService
{
    private const int StartValueCounter = 30;
    private const int MillisecondsDelay = 1000;

    public async Task CountdownDelay(CancellationToken cancellationToken)
    {
        await Task.Delay(MillisecondsDelay, cancellationToken);
    }

    public int StartValue
    {
        get => StartValueCounter;
    }
}