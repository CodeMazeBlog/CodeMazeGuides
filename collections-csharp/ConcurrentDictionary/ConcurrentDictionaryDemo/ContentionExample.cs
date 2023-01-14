using System.Collections.Concurrent;
using System.Diagnostics;

public class ContentionExample
{
    public const int MaxIterations = 100000;
    public const int MaxStateEntries = 10;
    public const int ProcessingSteps = 40;

    public IEnumerable<int> State => _sharedState.Values;

    private ConcurrentDictionary<int, int> _sharedState = new();

    private Func<bool> CheckStateIsEmpty = () => false;

    public void Run()
    {
        var stopwatch = Stopwatch.StartNew();
        RunFirstVariant();

        Console.WriteLine($"\nChecking entries processing took {stopwatch.Elapsed.TotalSeconds:N2} s.\n");

        stopwatch.Restart();
        RunSecondVariant();

        Console.WriteLine($"\nChecking keys processing took {stopwatch.Elapsed.TotalSeconds:N2} s.\n");
    }

    public void RunSecondVariant()
    {
        _sharedState = new();
        CheckStateIsEmpty = () => !_sharedState.Keys.Any();
        Parallel.ForEach(Enumerable.Range(0, ProcessingSteps), ProcessingStep);
    }

    public void RunFirstVariant()
    {
        _sharedState = new();
        CheckStateIsEmpty = () => !_sharedState.Any();
        Parallel.ForEach(Enumerable.Range(0, ProcessingSteps), ProcessingStep);
    }

    private void ProcessingStep(int stepNumber)
    {
        for (int iteration = 0; iteration < MaxIterations; iteration++)
        {
            var entryKey = iteration % MaxStateEntries;

            if (CheckStateIsEmpty())
            {
                Console.WriteLine($"Processing step {stepNumber} found empty shared state.");
            }

            _sharedState.AddOrUpdate(
                entryKey,
                key => 1,
                (key, currentValue) => currentValue + 1);
        }
    }
}

