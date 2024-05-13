using IntroductionToSemaphoreInCsharp.Models;
using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithSemaphoreSlim
{
    private static List<string> _sharedResource = new List<string>();
    private static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(3, 3);

    public static async Task AccessWithSemaphoreSlimAsync(int sleepDelay)
    {
        var tasks = new Task[10];
        for (int i = 0; i < 10; i++)
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

        await Task.Delay(processParams.SleepDelay); //mock a long-running operation - pretend work is happening
        Console.WriteLine("SemaphoreSlim: Thread {0} is accessing {1} at {2}",
                processParams.SequenceNo,
                nameof(_sharedResource),
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));

        _semaphoreSlim.Release();
    }
}