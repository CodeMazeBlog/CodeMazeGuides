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

        var random = Random.Shared;

        // Generate random values for dictionaryA
        for (var i = 0; i < 100; i++)
        {
            var key = random.Next(100);
            var value = GenerateRandomValue();

            if (!_dictionaryA.ContainsKey(key))
            {
                _dictionaryA.Add(key, value);
            }
            else
            {
                i--; // Retry generating a unique key
            }
        }

        // Generate random values for dictionaryB
        for (int i = 0; i < _dictionaryA.Count; i++)
        {
            var key = random.Next(100, 200);
            var value = GenerateRandomValue();

            if (!_dictionaryB.ContainsKey(key))
            {
                _dictionaryB.Add(key, value);
            }
        }
    }

    private string GenerateRandomValue()
    {
        var random = Random.Shared;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        return new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
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