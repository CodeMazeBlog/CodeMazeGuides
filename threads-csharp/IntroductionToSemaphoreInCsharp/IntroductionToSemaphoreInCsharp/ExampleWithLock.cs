using IntroductionToSemaphoreInCsharp.Models;
using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithLock
{
    private static List<string> _sharedResource = new List<string>();
    private static readonly object _locker = new object();

    public static void AccessWithLock(int sleepDelay)
    {
        var threads = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            var processParams = new ProcessParams(i, sleepDelay);
            var thread = new Thread(WorkerWithLock);
            thread.Start(processParams);
            threads[i] = thread;
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    static void WorkerWithLock(object? processParams)
    {
        lock (_locker)
        {
            var processParamsObj = processParams as ProcessParams;
            if (processParamsObj is null)
                return;

            Thread.Sleep(processParamsObj.SleepDelay); //mock a long-running operation - pretend work is happening
            Console.WriteLine("Lock: Thread {0} is accessing {1} at {2}",
                processParamsObj.SequenceNo,
                nameof(_sharedResource),
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
        }
    }
}