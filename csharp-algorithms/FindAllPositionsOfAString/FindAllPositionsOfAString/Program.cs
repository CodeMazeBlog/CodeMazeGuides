using BenchmarkDotNet.Running;
using FindAllPositionsOfAString;

var benchmark = args.Length >= 1;

if (benchmark)
{
    _ = BenchmarkRunner.Run<SearcherBenchmarks>();
}
else
{
    var searchers = new ISearcher[]
    {
        new SearchUsingIndexOf(),
        new SearchUsingRegex(),
        new SearchUsingKMPAlgorithm(),
        new SearchUsingBruteForceAlgorithm(),
    };

    foreach (SearchPair searchPair in SearchingSamples.SampleForProgram())
    {
        Console.WriteLine($"\n\n");

        foreach (ISearcher searcher in searchers)
        {
            searcher.Initialize(searchPair.SearchValue);
            List<int> positions = searcher.FindAll(searchPair.Text);

            Console.WriteLine($"Using {searcher.GetType().Name}");
            Console.WriteLine($" ** Found '{searchPair.SearchValue}' {positions.Count} times in the text.");
            Console.WriteLine($" ** Positions: {string.Join(", ", positions)}");
        }
    }
}
