using System.Collections.Concurrent;

public class BetterApproach
{
    public const int MaxIterations = 100;
    public const int MaxStateEntries = 10;
    public const int ProcessingSteps = 40;

    public IEnumerable<int> State => _sharedState.Values;

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
                entryKey,                                   // the key that we want to update
                key => 1,                                   // initial value factory, in case the key is not found
                (key, currentValue) => currentValue + 1);   // updated value factory, in case the key already exists
        }
    }

    private void PrintState()
    {
        foreach (var entry in _sharedState)
        {
            Console.WriteLine($"{entry.Key}\t{entry.Value}");
        }
    }
}
