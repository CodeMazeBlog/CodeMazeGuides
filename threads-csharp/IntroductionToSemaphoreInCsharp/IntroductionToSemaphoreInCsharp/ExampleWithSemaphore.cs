using IntroductionToSemaphoreInCsharp.Models;
using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithSemaphore
{
    private static List<string> _sharedResource = new List<string>();
    private static readonly Semaphore _semaphore = new Semaphore(initialCount: 3, maximumCount: 3);

    public static void AccessWithSemaphore(int sleepDelay)
    {
        var threads = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            var processParams = new ProcessParams(i, sleepDelay);
            var thread = new Thread(WorkerWithSemaphore);
            thread.Start(processParams);
            threads[i] = thread;
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    static void WorkerWithSemaphore(object? processParams)
    {
        var processParamsObj = processParams as ProcessParams;
        if (processParamsObj is null)
            return;

        _semaphore.WaitOne();

        Thread.Sleep(processParamsObj.SleepDelay); //mock a long-running operation - pretend work is happening
        Console.WriteLine("Semaphore: Thread {0} is accessing {1} at {2}",
                processParamsObj.SequenceNo,
                nameof(_sharedResource),
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));

        _semaphore.Release();
    }
}