using BenchmarkDotNet.Attributes;
using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;

namespace FindAllPositionsOfAString.Benchmarks;

public class SearcherBenchmarks
{
    private SearchUsingBruteForceAlgorithm? _searchUsingBruteForceAlgorithm;
    private SearchUsingIndexOf? _searchUsingIndexOf;
    private SearchUsingKMPAlgorithm? _searchUsingKMPAlgorithm;
    private SearchUsingRegexWithMatch? _searchUsingRegexWithMatch;
    private SearchUsingSearchValues? _searchUsingSearchValues;

    [Params(0, 1, 2, 3)]
    public int Index { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _searchUsingBruteForceAlgorithm = new(SearchingSamples.SearchPairs[Index].SearchText, false, true);
        _searchUsingIndexOf= new(SearchingSamples.SearchPairs[Index].SearchText, false, true);
        _searchUsingKMPAlgorithm= new(SearchingSamples.SearchPairs[Index].SearchText, false, true);
        _searchUsingRegexWithMatch= new(SearchingSamples.SearchPairs[Index].SearchText, false, true);
        _searchUsingSearchValues= new(SearchingSamples.SearchPairs[Index].SearchText, false, true);
    }

    [Benchmark(Baseline = true)]
    public List<int> BenchmarkSearchUsingIndexOf()
    {
        return _searchUsingIndexOf!.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }

    [Benchmark]
    public List<int> BenchmarkSearchUsingSearchValues()
    {
        return _searchUsingSearchValues!.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }

    [Benchmark]
    public List<int> BenchmarkSearchUsingRegexMatch()
    {
        return _searchUsingRegexWithMatch!.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }

    [Benchmark]
    public List<int> BenchmarkSearchUsingBruteForce()
    {
        return _searchUsingBruteForceAlgorithm!.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }

    [Benchmark]
    public List<int> BenchmarkSearchUsingKMP()
    {
        return _searchUsingKMPAlgorithm!.FindAll(SearchingSamples.SearchPairs[Index].Text);
    }
}
