using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithMutex
{
    private static List<string> _sharedResource = new List<string>();
    private static readonly Mutex _mutex = new Mutex();

    public static void AccessWithMutex()
    {
        var threads = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            var thread = new Thread(WorkerWithMutex);
            thread.Start(i);
            threads[i] = thread;
        }

        //Join them as otherwise threads are fire-and-forget
        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    static void WorkerWithMutex(object? sequenceNo)
    {
        _mutex.WaitOne();
        
        Thread.Sleep(2000); //mock a long-running operation - pretend work is happening
        Console.WriteLine("Mutex: Thread {0} is accessing {1} at {2}",
                sequenceNo,
                nameof(_sharedResource),
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));


        _mutex.ReleaseMutex();
    }
}
