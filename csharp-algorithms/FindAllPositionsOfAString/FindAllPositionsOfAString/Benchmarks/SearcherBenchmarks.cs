using BenchmarkDotNet.Attributes;
using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;


namespace FindAllPositionsOfAString.Benchmarks;

public class SearcherBenchmarks
{
    private readonly SearchUsingBruteForceAlgorithm searchUsingBruteForceAlgorithm = new();
    private readonly SearchUsingIndexOf searchUsingIndexOf = new();
    private readonly SearchUsingKMPAlgorithm searchUsingKMPAlgorithm = new();
    private readonly SearchUsingRegexWithMatch searchUsingRegexWithMatch = new();
    private readonly SearchUsingSearchValues searchUsingSearchValues = new();

    [Params(0, 1, 2, 3)]
    public int Index { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        searchUsingBruteForceAlgorithm.Initialize(SearchingSamples.SearchPairs[Index].SearchText);
        searchUsingIndexOf.Initialize(SearchingSamples.SearchPairs[Index].SearchText);
        searchUsingKMPAlgorithm.Initialize(SearchingSamples.SearchPairs[Index].SearchText);
        searchUsingRegexWithMatch.Initialize(SearchingSamples.SearchPairs[Index].SearchText);
        searchUsingSearchValues.Initialize(SearchingSamples.SearchPairs[Index].SearchText);
    }

    [Benchmark(Baseline = true)]
    public List<int> BenchmarkSearchUsingIndexOf()
    {
        return searchUsingIndexOf.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }

    [Benchmark]
    public List<int> BenchmarkSearchUsingSearchValues()
    {
        return searchUsingSearchValues.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }

    [Benchmark]
    public List<int> BenchmarkSearchUsingRegexMatch()
    {
        return searchUsingRegexWithMatch.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }

    [Benchmark]
    public List<int> BenchmarkSearchUsingBruteForce()
    {
        return searchUsingBruteForceAlgorithm.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }

    [Benchmark]
    public List<int> BenchmarkSearchUsingKMP()
    {
        return searchUsingKMPAlgorithm.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }
}
