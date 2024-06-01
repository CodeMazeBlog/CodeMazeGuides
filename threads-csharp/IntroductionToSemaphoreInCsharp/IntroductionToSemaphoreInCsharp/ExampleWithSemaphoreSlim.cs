using IntroductionToSemaphoreInCsharp.Models;
using System.Collections.Concurrent;
using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithSemaphoreSlim
{
    private static readonly List<string> _sharedResource = [];
    private static readonly SemaphoreSlim _semaphoreSlim = new(3, 3);

    public static ConcurrentQueue<string> OutputQueue { get; private set; } = new();

    public static async Task AccessWithSemaphoreSlimAsync(int sleepDelay)
    {
        var tasks = new Task[Constants.NumberOfThreads];
        for (int i = 0; i < Constants.NumberOfThreads; i++)
        {
            var processParams = new ProcessParams(i, sleepDelay);
            var task = WorkerWithSemaphoreSlimAsync(processParams);
            tasks[i] = task;
        }

        await Task.WhenAll(tasks);
    }

    static async Task WorkerWithSemaphoreSlimAsync(ProcessParams processParams)
    {
        if (processParams is null)
            return;

        await _semaphoreSlim.WaitAsync();

        await Task.Delay(processParams.SleepDelay);

        var output = string.Format("SemaphoreSlim: Thread {0} is accessing {1} at {2}",
                                   processParams.SequenceNo,
                                   nameof(_sharedResource),
                                   DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));

        OutputQueue.Enqueue(output);

        _semaphoreSlim.Release();
    }
}