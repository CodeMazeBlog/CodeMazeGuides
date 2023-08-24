public class NaiveExample
{
    public const int MaxIterations = 100;
    public const int MaxStateEntries = 10;
    public const int ProcessingSteps = 40;

    public IEnumerable<int> State => _sharedState.Values;

    private Dictionary<int, int> _sharedState = new(MaxStateEntries);

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
            if (!_sharedState.TryGetValue(entryKey, out int entryValue))
            {
                entryValue = 0;
            }
            _sharedState[entryKey] = entryValue + 1;
            Thread.Sleep(1);
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

