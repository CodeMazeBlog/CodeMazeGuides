using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithLock
{
    private static List<string> _sharedResource = new List<string>();
    private static readonly object _locker = new object();

    public static void AccessWithLock()
    {
        var threads = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            var thread = new Thread(WorkerWithLock);
            thread.Start(i);
            threads[i] = thread;
        }

        //Join them as otherwise threads are fire-and-forget
        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    static void WorkerWithLock(object? sequenceNo)
    {
        lock (_locker)
        {
            Thread.Sleep(2000); //mock a long-running operation - pretend work is happening
            Console.WriteLine("Lock: Thread {0} is accessing {1} at {2}",
                sequenceNo,
                nameof(_sharedResource),
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
        }
    }
}