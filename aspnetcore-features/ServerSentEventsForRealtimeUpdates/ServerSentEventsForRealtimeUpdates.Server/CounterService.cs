namespace ServerSentEventsForRealtimeUpdates.Server;

public class CounterService : ICounterService
{
    private const int cStartValue = 30;
    private const int cMillisecondsDelay = 1000;

    public async Task CountdownDelay(CancellationToken cancellationToken)
    {
        await Task.Delay(cMillisecondsDelay, cancellationToken);
    }

    public int StartValue
    {
        get => cStartValue;
    }
}