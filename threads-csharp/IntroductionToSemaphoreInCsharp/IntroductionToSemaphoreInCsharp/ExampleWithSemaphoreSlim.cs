using System.Globalization;

namespace IntroductionToSemaphoreInCsharp;

public class ExampleWithSemaphoreSlim
{
    private static List<string> _sharedResource = new List<string>();
    private static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(3, 3); // Initialize semaphore with 3 permits and 3 initial count

    public static async Task AccessWithSemaphoreSlimAsync()
    {
        var tasks = new Task[10];
        for (int i = 0; i < 10; i++)
        {
            var task = WorkerWithSemaphoreSlimAsync(i);
            tasks[i] = task;
        }
        await Task.WhenAll(tasks);
    }

    static async Task WorkerWithSemaphoreSlimAsync(int sequenceNo)
    {
        await _semaphoreSlim.WaitAsync();

        await Task.Delay(2000); //mock a long-running operation - pretend work is happening
        Console.WriteLine("SemaphoreSlim: Thread {0} is accessing {1} at {2}",
                sequenceNo,
                nameof(_sharedResource),
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));

        _semaphoreSlim.Release();
    }
}
