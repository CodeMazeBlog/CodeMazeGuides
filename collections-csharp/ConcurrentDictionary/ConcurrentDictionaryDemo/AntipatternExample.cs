using System.Collections.Concurrent;

class AntipatternExample
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
            if (!sharedState.TryGetValue(entryKey, out int entryValue))
            {
                sharedState[entryKey] = 0;
            }
            sharedState[entryKey]++;
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
