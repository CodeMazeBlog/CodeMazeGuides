namespace PeriodicTimerCSharp;

public class PeriodicTimerMethods
{
    public static int[] CreateRandomArray(int size)
    {
        var array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = Random.Shared.Next();
        }
        
        return array;
    }

    public static async Task<PeriodicTimer> RandomArrayTimerAsync() 
    {
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        using var token = new CancellationTokenSource();
        var stopWatch = System.Diagnostics.Stopwatch.StartNew();
        var taskDuration = 6;
        var numberOfElements = 5;
        var numberOfArrays = 1;

        while (await timer.WaitForNextTickAsync(token.Token))
        {
            if (!token.IsCancellationRequested)
            {
                var array = CreateRandomArray(numberOfElements);

                foreach (var item in array) 
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine($"Elapsed time: {stopWatch.Elapsed.Seconds}s and {numberOfArrays++} arrays created");

                await Task.Delay(1000);

                if (stopWatch.Elapsed.TotalSeconds > taskDuration)
                {
                    return timer;
                }
            }
        }
        
        return timer;
    }
}