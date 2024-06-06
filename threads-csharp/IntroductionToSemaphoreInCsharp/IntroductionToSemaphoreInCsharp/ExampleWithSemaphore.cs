using IntroductionToSemaphoreInCsharp.Models;
using System.Collections.Concurrent;
using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithSemaphore
{
    private static readonly ConcurrentQueue<string> _outputQueue = new();
    private static readonly Semaphore _semaphore = new(initialCount: 3, maximumCount: 3);

    public static async Task<IReadOnlyCollection<string>> AccessWithSemaphoreAsync(int sleepDelay)
    {
        var tasks = new Task[Constants.NumberOfThreads];
        for (int i = 0; i < Constants.NumberOfThreads; i++)
        {
            var processParams = new ProcessParams(i, sleepDelay);
            var task = WorkerWithSemaphoreAsync(processParams);
            tasks[i] = task;
        }

        await Task.WhenAll(tasks);

        return _outputQueue;
    }

    static async Task WorkerWithSemaphoreAsync(ProcessParams processParams)
    {
        _semaphore.WaitOne();

        await Task.Delay(processParams.SleepDelay);

        var output = string.Format("Semaphore: Thread {0} is accessing {1} at {2}",
                                   processParams.SequenceNo,
                                   nameof(_outputQueue),
                                   DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));

        _outputQueue.Enqueue(output);

        _semaphore.Release();
    }

    public static void ReleaseMultipleTimes()
    {
        var semaphoreForError = new Semaphore(initialCount: 2, maximumCount: 2);

        semaphoreForError.WaitOne();
        semaphoreForError.Release();

        semaphoreForError.Release();
    }
}