using IntroductionToSemaphoreInCsharp.Models;
using System.Collections.Concurrent;
using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithSemaphore
{
    private static readonly List<string> _sharedResource = [];
    private static readonly Semaphore _semaphore = new(initialCount: 3, maximumCount: 3);

    public static ConcurrentQueue<string> OutputQueue { get; private set; } = new();

    public static async Task AccessWithSemaphoreAsync(int sleepDelay)
    {
        var tasks = new Task[Constants.NumberOfThreads];
        for (int i = 0; i < Constants.NumberOfThreads; i++)
        {
            var processParams = new ProcessParams(i, sleepDelay);
            var task = WorkerWithSemaphoreAsync(processParams);
            tasks[i] = task;
        }

        await Task.WhenAll(tasks);
    }

    static async Task WorkerWithSemaphoreAsync(ProcessParams processParams)
    {
        _semaphore.WaitOne();

        await Task.Delay(processParams.SleepDelay);

        var output = string.Format("Semaphore: Thread {0} is accessing {1} at {2}",
                                   processParams.SequenceNo,
                                   nameof(_sharedResource),
                                   DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));

        OutputQueue.Enqueue(output);

        _semaphore.Release();
    }
}