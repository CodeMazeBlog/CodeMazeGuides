class SecondExample
{
    private const int MaxIterations = 100;
    private const int MaxStateEntries = 10;
    private Dictionary<int, int> sharedState = new(MaxStateEntries) { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, };

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
