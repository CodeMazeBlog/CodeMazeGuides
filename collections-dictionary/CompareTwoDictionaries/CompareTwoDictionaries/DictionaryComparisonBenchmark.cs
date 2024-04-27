using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CompareTwoDictionaries;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DictionaryComparisonBenchmark
{
    private static readonly Dictionary<int, string> _dict1
        = new()
        {
            {1, "Rosary Ogechi"},
            {2, "Clare Chiamaka"},
        };

    private static readonly Dictionary<int, string> _dict2
        = new()
        {
            {1, "Rosary Ogechi"},
            {2, "Clare Chiamaka"},
        };

    private readonly DictionaryComparisonHelper _dictComparer = new(_dict1, _dict2);

    [Benchmark]
    public bool UseSequenceEqual()
        => _dictComparer.UseSequenceEqual();

    [Benchmark]
    public bool UseEnumerableAll()
        => _dictComparer.UseEnumerableAll();

    [Benchmark]
    public bool UseForeachLoop()
        => _dictComparer.UseForeachLoop();
}