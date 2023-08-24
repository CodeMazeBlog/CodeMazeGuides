using System.Collections.Concurrent;

public class MemoryLeakExample
{
    public const int MaxIterations = 100;
    public const int MaxStateEntries = 10;
    public const int ProcessingSteps = 20;

    public IEnumerable<int> State => _sharedState.Values;

    public int[] NewValueCreated { get; private set; } = new int[MaxStateEntries];

    public int[] UpdateValueCreated { get; private set; } = new int[MaxStateEntries];

    private ConcurrentDictionary<int, int> _sharedState = new();

    public void Run()
    {
        Parallel.ForEach(Enumerable.Range(0, ProcessingSteps), ProcessingStep);

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
        Thread.Sleep(3);
        Interlocked.Increment(ref UpdateValueCreated[key]);
        return currentValue + 1;
    }

    private int InitialValueFactory(int key)
    {
        Thread.Sleep(3);
        Interlocked.Increment(ref NewValueCreated[key]);
        return 1;
    }

    private void PrintState()
    {
        foreach (var entry in _sharedState)
        {
            Console.WriteLine($"{entry.Key}\t{entry.Value}");
        }

        Console.WriteLine(new string('-', 20));

        for (int key = 0; key < MaxStateEntries; key++)
        {
            Console.WriteLine($@"Initial value for key [{key}] created {NewValueCreated[key]} times.");
        }

        Console.WriteLine(new string('-', 20));

        for (int key = 0; key < MaxStateEntries; key++)
        {
            Console.WriteLine($@"Update value for key [{key}] created {UpdateValueCreated[key]} times.");
        }
    }
}

