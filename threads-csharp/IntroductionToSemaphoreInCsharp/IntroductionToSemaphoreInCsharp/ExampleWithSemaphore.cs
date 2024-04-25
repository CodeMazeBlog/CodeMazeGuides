using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithSemaphore
{
    private static List<string> _sharedResource = new List<string>();
    private static readonly Semaphore _semaphore = new Semaphore(initialCount: 3, maximumCount: 3); // Initialize semaphore with 3 max permits and 3 current counter

    public static void AccessWithSemaphore()
    {
        var threads = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            var thread = new Thread(WorkerWithSemaphore);
            thread.Start(i);
            threads[i] = thread;
        }

        //Join them as otherwise threads are fire-and-forget
        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    static void WorkerWithSemaphore(object? threadNo)
    {
        _semaphore.WaitOne();

        Thread.Sleep(2000); //mock a long-running operation - pretend work is happening
        Console.WriteLine($"Semaphore: Thread {threadNo} is accessing {nameof(_sharedResource)} at {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                        CultureInfo.InvariantCulture)}");

        _semaphore.Release();
    }
}
