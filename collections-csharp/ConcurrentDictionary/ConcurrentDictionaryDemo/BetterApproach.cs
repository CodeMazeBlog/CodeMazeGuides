using System.Collections.Concurrent;

class BetterApproach
{
    private const int MaxIterations = 100;
    private const int MaxStateEntries = 10;
    private ConcurrentDictionary<int, int> sharedState = new();

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
            sharedState.AddOrUpdate(
            entryKey,                                       // the key that we want to update
                key => 1,                                   // initial value factory, in case the key is not found
                (key, currentValue) => currentValue + 1);   // updated value factory, in case the key already exists
        }
    }

    private void PrintState()
    {
        foreach (var entry in sharedState)
        {
            Console.WriteLine($"{entry.Key}\t{entry.Value}");
        }
    }
}

