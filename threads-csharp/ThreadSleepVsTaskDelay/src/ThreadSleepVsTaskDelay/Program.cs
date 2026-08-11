using System.Diagnostics;

namespace ThreadSleepVsTaskDelay;

public class Program
{
    public static async Task UseTaskDelay(int delayMilliseconds = 2000)
    {
        Console.WriteLine($"Before delay: Thread id = {Environment.CurrentManagedThreadId}");
        await Task.Delay(delayMilliseconds);
        Console.WriteLine($"After delay: Thread id = {Environment.CurrentManagedThreadId}");
    }

    public static void UseThreadSleep(int sleepMilliseconds = 2000)
    {
        Console.WriteLine($"Before sleep: Thread id = {Environment.CurrentManagedThreadId}");
        Thread.Sleep(sleepMilliseconds);
        Console.WriteLine($"After sleep: Thread id = {Environment.CurrentManagedThreadId}");
    }

    public static async Task<long> RunBlockingWorkAsync(int workItems, int milliseconds)
    {
        var stopwatch = Stopwatch.StartNew();
        var blocking = Enumerable.Range(0, workItems)
            .Select(_ => Task.Run(() => Thread.Sleep(milliseconds)));

        await Task.WhenAll(blocking);

        return stopwatch.ElapsedMilliseconds;
    }

    public static async Task<long> RunNonBlockingWorkAsync(int workItems, int milliseconds)
    {
        var stopwatch = Stopwatch.StartNew();
        var waiting = Enumerable.Range(0, workItems)
            .Select(_ => Task.Delay(milliseconds));

        await Task.WhenAll(waiting);

        return stopwatch.ElapsedMilliseconds;
    }

    private static async Task RefreshCacheAsync()
    {
        await Task.Delay(50);
    }

    public static async Task RunPeriodicRefreshAsync(CancellationToken cancellationToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

        while (await timer.WaitForNextTickAsync(cancellationToken))
        {
            await RefreshCacheAsync(); // runs every second, no drift, cancellable
        }
    }

    private static async Task Main()
    {
        Console.WriteLine("Starting Thread.Sleep test...");
        UseThreadSleep();
        Console.WriteLine("Thread.Sleep test completed.\n");

        Console.WriteLine("Starting Task.Delay test...");
        await UseTaskDelay();
        Console.WriteLine("Task.Delay test completed.\n");

        Console.WriteLine($"Processor count: {Environment.ProcessorCount}");
        var blockingMs = await RunBlockingWorkAsync(50, 1000);
        Console.WriteLine($"50 blocking items: {blockingMs} ms");
        var nonBlockingMs = await RunNonBlockingWorkAsync(50, 1000);
        Console.WriteLine($"50 non-blocking items: {nonBlockingMs} ms");

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3.5));
        try
        {
            await RunPeriodicRefreshAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Periodic refresh canceled.");
        }
    }
}
