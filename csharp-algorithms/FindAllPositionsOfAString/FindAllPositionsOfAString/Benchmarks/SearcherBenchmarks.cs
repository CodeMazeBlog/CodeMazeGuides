using BenchmarkDotNet.Attributes;
using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;


namespace FindAllPositionsOfAString.Benchmarks;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
public class SearcherBenchmarks
{
    public static IEnumerable<object[]> Samples() => SearchingSamples.SamplesForBenchmark();

    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(Samples))]
    public void BenchmarkSearchUsingIndexOf(string text, string searchText)
    {
        var searcher = new SearchUsingIndexOf();
        var result = searcher.FindAll(text, searchText);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public void BenchmarkSearchUsingRegexMatch(string text, string searchText)
    {
        var searcher = new SearchUsingRegexWithMatch();
        var result = searcher.FindAll(text, searchText);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public void BenchmarkSearchUsingRegexMatches(string text, string searchText)
    {
        var searcher = new SearchUsingRegexWithMatches();
        searcher.SkipWholeFoundText = true;
        var result = searcher.FindAll(text, searchText);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public void BenchmarkSearchUsingBruteForce(string text, string searchText)
    {
        var searcher = new SearchUsingBruteForceAlgorithm();
        var result = searcher.FindAll(text, searchText);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public void BenchmarkSearchUsingKMP(string text, string searchText)
    {
        var searcher = new SearchUsingKMPAlgorithm();
        var result = searcher.FindAll(text, searchText);
    }
}
#pragma warning restore IDE0059 // Unnecessary assignment of a value
