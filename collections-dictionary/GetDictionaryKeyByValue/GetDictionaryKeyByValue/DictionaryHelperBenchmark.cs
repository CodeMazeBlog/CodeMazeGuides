using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace GetDictionaryKeyByValue;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DictionaryHelperBenchmark
{
    private static readonly Dictionary<string, string> _benchmarkDict = GetDictionary();

    private readonly DictionaryHelper _dictionaryHelper = new(_benchmarkDict, "value99999");

    private static Dictionary<string, string> GetDictionary()
    {
        var benchmarkDict = new Dictionary<string, string>(100000);
        for (int i = 1; i <= 100000; i++)
        {
            string key = $"key{i}";
            string value = $"value{i}";
            benchmarkDict.Add(key, value);
        }

        return benchmarkDict;
    }

    [Benchmark]
    public string? UseReverseDictionary()
        => _dictionaryHelper.UseReverseDictionary();

    [Benchmark]
    public string? UseToLookup()
          => _dictionaryHelper.UseToLookup();

    [Benchmark]
    public string? LoopThroughTheKeyValuePairs()
    => _dictionaryHelper.LoopThroughKeyValuePairs();

    [Benchmark]
    public string? LoopThroughTheKeys()
        => _dictionaryHelper.LoopThroughKeys();
}