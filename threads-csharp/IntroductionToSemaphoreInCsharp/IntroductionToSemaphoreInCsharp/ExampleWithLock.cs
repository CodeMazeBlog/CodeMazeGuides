using IntroductionToSemaphoreInCsharp.Models;
using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithLock
{
    private static List<string> _sharedResource = new List<string>();
    private static readonly object _locker = new object();

    public static async Task AccessWithLockAsync(int sleepDelay)
    {
        var tasks = new Task[10];
        for (int i = 0; i < 10; i++)
        {
            var processParams = new ProcessParams(i, sleepDelay);
            var task = WorkerWithLockAsync(processParams);
            tasks[i] = task;
        }

        await Task.WhenAll(tasks);
    }

    static Task WorkerWithLockAsync(ProcessParams processParams)
    {
        lock (_locker)
        {
            Thread.Sleep(processParams.SleepDelay);
            Console.WriteLine("Lock: Thread {0} is accessing {1} at {2}",
                processParams.SequenceNo,
                nameof(_sharedResource),
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));

            return Task.CompletedTask;
        }
    }
}