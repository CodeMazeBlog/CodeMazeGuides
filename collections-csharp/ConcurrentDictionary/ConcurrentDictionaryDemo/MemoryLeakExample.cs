using System.Collections.Concurrent;

class MemoryLeakExample
{
    private const int MaxIterations = 100;
    private const int MaxStateEntries = 10;
    private ConcurrentDictionary<int, int> _sharedState = new();

    public void Run()
    {
        Parallel.ForEach(Enumerable.Range(0, 20), ProcessingStep);

        PrintState();
    }

    private void ProcessingStep(int stepNumber)
    {
        for (int iteration = 0; iteration < MaxIterations; iteration++)
        {
            var entryKey = iteration % MaxStateEntries;
            _sharedState.AddOrUpdate(
                entryKey,
                InitialValueFactory,
                UpdatedValueFactory);
        }
    }

    private int UpdatedValueFactory(int key, int currentValue)
    {
        Console.WriteLine($@"Update value for key [{key}] created from [{currentValue}].");
        return currentValue + 1;
    }

    private int InitialValueFactory(int key)
    {
        Console.WriteLine($@"Initial value for key [{key}] created.");
        return 1;
    }

    private void PrintState()
    {
        foreach (var entry in _sharedState)
        {
            Console.WriteLine($"{entry.Key}\t{entry.Value}");
        }
    }
}

