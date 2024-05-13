using IntroductionToSemaphoreInCsharp.Models;
using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithMutex
{
    private static List<string> _sharedResource = new List<string>();
    private static readonly Mutex _mutex = new Mutex();

    public static void AccessWithMutex(int sleepDelay)
    {
        var threads = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            var processParams = new ProcessParams(i, sleepDelay);
            var thread = new Thread(WorkerWithMutex);
            thread.Start(processParams);
            threads[i] = thread;
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    static void WorkerWithMutex(object? processParams)
    {
        var processParamsObj = processParams as ProcessParams;
        if (processParamsObj is null)
            return;

        _mutex.WaitOne();

        Thread.Sleep(processParamsObj.SleepDelay); //mock a long-running operation - pretend work is happening
        Console.WriteLine("Mutex: Thread {0} is accessing {1} at {2}",
                processParamsObj.SequenceNo,
                nameof(_sharedResource),
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));


        _mutex.ReleaseMutex();
    }
}