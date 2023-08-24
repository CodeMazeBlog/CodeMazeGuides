public class SecondExample
{
    public const int MaxIterations = 100;
    public const int MaxStateEntries = 10;
    public const int ProcessingSteps = 40;

    public IEnumerable<int> State => _sharedState.Values;

    private Dictionary<int, int> _sharedState = new(MaxStateEntries) { { 0, 0 }, { 1, 0 }, { 2, 0 },
                                                                       { 3, 0 }, { 4, 0 }, { 5, 0 },
                                                                       { 6, 0 }, { 7, 0 }, { 8, 0 },
                                                                       { 9, 0 }, };

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
            _sharedState[entryKey]++;
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
