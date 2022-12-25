using System.Collections.Concurrent;
using System.Diagnostics;

class ContentionExample
{
    private const int MaxIterations = 100000;
    private const int MaxStateEntries = 10;
    private ConcurrentDictionary<int, int> _sharedState = new();

    public void Run()
    {
        var stopwatch = Stopwatch.StartNew();
        Parallel.ForEach(Enumerable.Range(0, 20), CheckingEntriesProcessingStep);

        Console.WriteLine($"\nChecking entries processing took {stopwatch.Elapsed.TotalSeconds:N2} s.\n");

        _sharedState = new();

        stopwatch.Restart();
        Parallel.ForEach(Enumerable.Range(0, 20), CheckingKeysProcessingStep);

        Console.WriteLine($"\nChecking keys processing took {stopwatch.Elapsed.TotalSeconds:N2} s.\n");
    }

    private void CheckingEntriesProcessingStep(int stepNumber)
    {
        for (int iteration = 0; iteration < MaxIterations; iteration++)
        {
            var entryKey = iteration % MaxStateEntries;

            if (!_sharedState.Any())
            {
                Console.WriteLine($"Processing step {stepNumber} found empty shared state.");
            }

            _sharedState.AddOrUpdate(
                entryKey,
                key => 1,
                (key, currentValue) => currentValue + 1);
        }
    }

    private void CheckingKeysProcessingStep(int stepNumber)
    {
        for (int iteration = 0; iteration < MaxIterations; iteration++)
        {
            var entryKey = iteration % MaxStateEntries;

            if (!_sharedState.Keys.Any())
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

