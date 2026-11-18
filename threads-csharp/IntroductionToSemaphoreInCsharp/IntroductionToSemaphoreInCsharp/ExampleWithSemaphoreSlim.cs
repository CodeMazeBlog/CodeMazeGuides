using IntroductionToSemaphoreInCsharp.Models;
using System.Collections.Concurrent;
using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithSemaphoreSlim
{
    private static readonly ConcurrentQueue<string> _outputQueue = new();
    private static readonly SemaphoreSlim _semaphoreSlim = new(initialCount: 3, maxCount: 3);

    public static async Task<IReadOnlyCollection<string>> AccessWithSemaphoreSlimAsync(int sleepDelay)
    {
        var tasks = new Task[Constants.NumberOfThreads];
        for (int i = 0; i < Constants.NumberOfThreads; i++)
        {
            var processParams = new ProcessParams(i, sleepDelay);
            var task = WorkerWithSemaphoreSlimAsync(processParams);
            tasks[i] = task;
        }

        await Task.WhenAll(tasks);

        return _outputQueue;
    }

    static async Task WorkerWithSemaphoreSlimAsync(ProcessParams processParams)
    {
        await _semaphoreSlim.WaitAsync();
        try
        {
            await Task.Delay(processParams.SleepDelay);

            var output = string.Format("SemaphoreSlim: Thread {0} is accessing {1} at {2}",
                                       processParams.SequenceNo,
                                       nameof(_outputQueue),
                                       DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));

            _outputQueue.Enqueue(output);
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }
}
