using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using static MergingDictionariesInCSharp.Methods;


[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class MergingMethodsBenchmark
{
    private Dictionary<int, string> _dictionaryA;
    private Dictionary<int, string> _dictionaryB;

    [GlobalSetup]
    public void Setup()
    {
        _dictionaryA = new Dictionary<int, string>();
        _dictionaryB = new Dictionary<int, string>();

        // Generate random values for dictionaryA
        for (var i = 0; i < 100; i++)
        {
            var randomValue = GenerateRandomValue();
            _dictionaryA.Add(i, randomValue);            
        }

        // Generate random values for dictionaryB
        for (int i = 100; i < 200; i++)
        {
            var randomValue = GenerateRandomValue();
            _dictionaryB.Add(i, randomValue);            
        }
    }

    private string GenerateRandomValue()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        return new string(Enumerable.Repeat(chars, 5).Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
    }

    [Benchmark]
    public Dictionary<int, string> ConcatBenchmark()
    {
        return ConcatMethod(_dictionaryA, _dictionaryB);
    }

    [Benchmark]
    public Dictionary<int, string> ForEachBenchmark()
    {
        return ForEachMethod(_dictionaryA, _dictionaryB);
    }

    [Benchmark]
    public Dictionary<int, string> GroupByBenchmark()
    {
        return GroupByMethod(_dictionaryA, _dictionaryB);
    }

    [Benchmark]
    public Dictionary<int, string> LookupBenchmark()
    {
        return LookupMethod(_dictionaryA, _dictionaryB);
    }

    [Benchmark]
    public Dictionary<int, string> UnionBenchmark()
    {
        return UnionMethod(_dictionaryA, _dictionaryB);
    }

    [Benchmark]
    public Dictionary<int, string> ListsBenchmark()
    {
        return UsingListsMethod(_dictionaryA, _dictionaryB);
    }
}