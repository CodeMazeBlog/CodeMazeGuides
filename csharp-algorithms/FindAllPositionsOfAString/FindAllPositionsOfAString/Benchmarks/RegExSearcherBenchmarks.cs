using BenchmarkDotNet.Attributes;
using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;


namespace FindAllPositionsOfAString.Benchmarks;

public class RegExSearcherBenchmarks
{
    private readonly SearchUsingRegexWithMatch searchUsingRegexWithMatch = new();
    private readonly SearchUsingRegexWithMatches searchUsingRegexWithMatches = new();

    [Params(0, 1, 2, 3)]
    public int Index { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        searchUsingRegexWithMatch.Initialize(SearchingSamples.SearchPairs[Index].SearchText);
        searchUsingRegexWithMatch.SkipWholeFoundText = true;

        searchUsingRegexWithMatches.Initialize(SearchingSamples.SearchPairs[Index].SearchText);
        searchUsingRegexWithMatches.SkipWholeFoundText = true;
    }

    [Benchmark(Baseline = true)]
    public List<int> BenchmarkSearchUsingRegexMatch()
    {
        return searchUsingRegexWithMatch.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }

    [Benchmark]
    public List<int> BenchmarkSearchUsingRegexMatches()
    {
        return searchUsingRegexWithMatches.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }
}
