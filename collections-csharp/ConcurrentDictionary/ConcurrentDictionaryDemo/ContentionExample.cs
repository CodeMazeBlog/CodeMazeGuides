using System.Collections.Concurrent;
using System.Diagnostics;

public class ContentionExample
{
    public const int MaxIterations = 100000;
    public const int MaxStateEntries = 10;
    public const int ProcessingSteps = 20;

    public IEnumerable<int> State => _sharedState.Values;

    private ConcurrentDictionary<int, int> _sharedState = new();

    private Func<bool> CheckStateIsEmpty = () => false;

    public void Run()
    {
        var stopwatch = Stopwatch.StartNew();
        RunWithEntryCheck();

        Console.WriteLine($"\nChecking entries processing took {stopwatch.Elapsed.TotalSeconds:N2} s.\n");

        stopwatch.Restart();
        RunWithKeysCheck();

        Console.WriteLine($"\nChecking keys processing took {stopwatch.Elapsed.TotalSeconds:N2} s.\n");
    }

    public void RunWithKeysCheck()
    {
        _sharedState = new();
        CheckStateIsEmpty = () => !_sharedState.Keys.Any();
        Parallel.ForEach(Enumerable.Range(0, ProcessingSteps), ProcessingStep);
    }

    public void RunWithEntryCheck()
    {
        _sharedState = new();
        CheckStateIsEmpty = () => !_sharedState.Any();
        Parallel.ForEach(Enumerable.Range(0, ProcessingSteps), ProcessingStep);
    }

    private void ProcessingStep(int stepNumber)
    {
        int emptyHits = 0;
        for (int iteration = 0; iteration < MaxIterations; iteration++)
        {
            var entryKey = iteration % MaxStateEntries;

            if (CheckStateIsEmpty())
            {
                emptyHits++;
            }

            _sharedState.AddOrUpdate(
                entryKey,
                key => 1,
                (key, currentValue) => currentValue + 1);
        }
    }
}

