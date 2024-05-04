using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CompareTwoDictionaries;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DictionaryEqualityComparerBenchmark
{
    private static readonly Dictionary<int, string> _dict1
        = Enumerable.Range(1, 1000).ToDictionary(k => k, v => v.ToString());

    private static readonly Dictionary<int, string> _dict2
        = Enumerable.Range(1, 1000).ToDictionary(k => k, v => v.ToString());

    [Benchmark]
    public bool UseSequenceEqual()
        => DictionaryEqualityComparer.UseSequenceEqual(_dict1, _dict2);

    [Benchmark]
    public bool UseEnumerableAll()
        => DictionaryEqualityComparer.UseEnumerableAll(_dict1, _dict2);

    [Benchmark]
    public bool UseForeachLoop()
        => DictionaryEqualityComparer.UseForeachLoop(_dict1, _dict2);
}