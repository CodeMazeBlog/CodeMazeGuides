namespace MutexClassInCSharp;

public static class MutexAsyncPitfall
{
    public static async Task<string> ReleaseAfterAwait()
    {
        using var mutex = new Mutex();
        var threadBefore = Environment.CurrentManagedThreadId;

        mutex.WaitOne();
        await Task.Delay(50);
        var threadAfter = Environment.CurrentManagedThreadId;

        try
        {
            mutex.ReleaseMutex();

            return $"Released on the same thread ({threadBefore}).";
        }
        catch (ApplicationException ex)
        {
            return $"{ex.GetType().Name} on thread {threadAfter} " +
                $"(acquired on thread {threadBefore}): {ex.Message}";
        }
    }
}
