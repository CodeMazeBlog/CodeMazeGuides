using BenchmarkDotNet.Attributes;
using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;


namespace FindAllPositionsOfAString.Benchmarks;

public class SearcherBenchmarks
{
    public static IEnumerable<object[]> Samples() => SearchingSamples.SamplesForBenchmark();

    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(Samples))]
    public List<int> BenchmarkSearchUsingIndexOf(string text, string searchText)
    {
        var searcher = new SearchUsingIndexOf();
        return searcher.FindAll(text, searchText);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public List<int> BenchmarkSearchUsingSearchValues(string text, string searchText)
    {
        var searcher = new SearchUsingSearchValues();
        return searcher.FindAll(text, searchText);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public List<int> BenchmarkSearchUsingRegexMatch(string text, string searchText)
    {
        var searcher = new SearchUsingRegexWithMatch();
        return searcher.FindAll(text, searchText);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public List<int> BenchmarkSearchUsingRegexMatches(string text, string searchText)
    {
        var searcher = new SearchUsingRegexWithMatches();
        searcher.SkipWholeFoundText = true;
        return searcher.FindAll(text, searchText);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public List<int> BenchmarkSearchUsingBruteForce(string text, string searchText)
    {
        var searcher = new SearchUsingBruteForceAlgorithm();
        return searcher.FindAll(text, searchText);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public List<int> BenchmarkSearchUsingKMP(string text, string searchText)
    {
        var searcher = new SearchUsingKMPAlgorithm();
        return searcher.FindAll(text, searchText);
    }
}
