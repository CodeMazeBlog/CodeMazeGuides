namespace WhenToUseReaderWriterLockSlimOverLockInCSharp;

public static class AsyncPitfall
{
    public static async Task<string> ExitWriteLockAfterAwait()
    {
        var readerWriterLockSlim = new ReaderWriterLockSlim();
        var threadBefore = Environment.CurrentManagedThreadId;

        readerWriterLockSlim.EnterWriteLock();
        await Task.Delay(50);
        var threadAfter = Environment.CurrentManagedThreadId;

        try
        {
            readerWriterLockSlim.ExitWriteLock();

            return $"Exited on the same thread ({threadBefore}).";
        }
        catch (SynchronizationLockException ex)
        {
            return $"{ex.GetType().Name} on thread {threadAfter} " +
                $"(entered on thread {threadBefore}): {ex.Message}";
        }
    }
}
