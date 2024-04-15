namespace ServerSentEventsForRealtimeUpdates.Server;

public class CounterService : ICounterService
{
    private const int StartValue = 30;
    private const int MillisecondsDelay = 1000;

    public async Task CountdownDelay()
    {
        await Task.Delay(MillisecondsDelay);
    }

    public int GetStartValue()
    {
        return StartValue;
    }
}