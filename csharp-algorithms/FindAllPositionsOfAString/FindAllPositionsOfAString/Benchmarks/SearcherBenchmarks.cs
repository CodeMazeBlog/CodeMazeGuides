using BenchmarkDotNet.Attributes;
using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;


namespace FindAllPositionsOfAString.Benchmarks;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
public class SearcherBenchmarks
{
    public static IEnumerable<object[]> Samples() => SearchingSamples.SamplesForBenchmark();

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public void BenchmarkSearchUsingIndexOf(string text, string searchValue)
    {
        var searcher = new SearchUsingIndexOf();
        searcher.Initialize(searchValue);
        var result = searcher.FindAll(text).ToList();
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public void BenchmarkSearchUsingRegex(string text, string searchValue)
    {
        var searcher = new SearchUsingRegexWithMatch();
        searcher.Initialize(searchValue);
        var result = searcher.FindAll(text).ToList();
    }

    [Benchmark]
    [ArgumentsSource(nameof(Samples))]
    public void BenchmarkSearchUsingKMPAlgorithm(string text, string searchValue)
    {
        var searcher = new SearchUsingKMPAlgorithm();
        searcher.Initialize(searchValue);
        var result = searcher.FindAll(text).ToList();
    }

    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(Samples))]
    public void BenchmarkSearchUsingBruteForceAlgorithm(string text, string searchValue)
    {
        var searcher = new SearchUsingBruteForceAlgorithm();
        searcher.Initialize(searchValue);
        var result = searcher.FindAll(text);
    }
}
#pragma warning restore IDE0059 // Unnecessary assignment of a value
