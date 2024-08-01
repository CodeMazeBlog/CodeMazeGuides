using BenchmarkDotNet.Attributes;
using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;

namespace FindAllPositionsOfAString.Benchmarks;

public class RegExSearcherBenchmarks
{
    private SearchUsingRegexWithMatch? _searchUsingRegexWithMatch;
    private SearchUsingRegexWithMatches? _searchUsingRegexWithMatches;

    [Params(0, 1, 2, 3)]
    public int Index { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _searchUsingRegexWithMatch = new(SearchingSamples.SearchPairs[Index].SearchText, true, true);

        _searchUsingRegexWithMatches = new(SearchingSamples.SearchPairs[Index].SearchText, true, true);
    }

    [Benchmark(Baseline = true)]
    public List<int> BenchmarkSearchUsingRegexMatch()
    {
        return _searchUsingRegexWithMatch!.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }

    [Benchmark]
    public List<int> BenchmarkSearchUsingRegexMatches()
    {
        return _searchUsingRegexWithMatches!.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }
}
