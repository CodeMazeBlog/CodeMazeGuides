namespace PeriodicTimerCSharp;

public class PeriodicTimerMethods
{
    private readonly PeriodicTimer _periodicTimer;
    private readonly CancellationTokenSource _cancellationToken = new();
    private Task? _task;
    private int _size;

    public PeriodicTimerMethods(TimeSpan timeSpan, int size) 
    {
        _periodicTimer = new PeriodicTimer(timeSpan);
        _size = size;
    }

    public static int[] CreateRandomArray(int size)
    {
        var array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = Random.Shared.Next();
        }
        
        return array;
    }

    public void Start() 
    {
        _task = RandomArrayTimerAsync();
    }

    private async Task RandomArrayTimerAsync() 
    {
        try 
        {
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            var numberOfArrays = 1;

            while (await _periodicTimer.WaitForNextTickAsync(_cancellationToken.Token)) 
            {
                var array = CreateRandomArray(_size);

                foreach (var item in array)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine($"Elapsed time: {stopWatch.Elapsed.Seconds}s" +
                    $" and {numberOfArrays++} arrays created");
                Console.WriteLine(DateTime.Now.ToString("O"));
            }
        }
        catch(OperationCanceledException) 
        {
        }
    }

    public async Task StopTaskAsync() 
    {
        if (_task is null) 
        {
            return;
        }

        _cancellationToken.Cancel();
        await _task;
        _cancellationToken.Dispose();
        Console.WriteLine("The array task was canceled");
    }
}