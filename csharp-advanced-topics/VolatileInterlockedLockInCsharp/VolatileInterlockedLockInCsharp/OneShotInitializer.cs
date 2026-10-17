namespace VolatileInterlockedLockInCsharp;

public sealed class OneShotInitializer
{
    private int _started;

    public bool TryStart() => Interlocked.Exchange(ref _started, 1) == 0;
}
