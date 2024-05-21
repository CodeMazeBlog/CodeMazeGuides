using IntroductionToSemaphoreInCsharp.Models;
using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithMutex
{
    private static List<string> _sharedResource = new List<string>();
    private static readonly Mutex _mutex = new Mutex();

    public static async Task AccessWithMutexAsync(int sleepDelay)
    {
        var tasks = new Task[10];
        for (int i = 0; i < 10; i++)
        {
            var processParams = new ProcessParams(i, sleepDelay);
            var task = WorkerWithMutexAsync(processParams);
            tasks[i] = task;
        }

        await Task.WhenAll(tasks);
    }

    static Task WorkerWithMutexAsync(ProcessParams processParams)
    {
        _mutex.WaitOne();

        Thread.Sleep(processParams.SleepDelay);
        
        Console.WriteLine("Mutex: Thread {0} is accessing {1} at {2}",
                processParams.SequenceNo,
                nameof(_sharedResource),
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));

        _mutex.ReleaseMutex();

        return Task.CompletedTask;
    }
}