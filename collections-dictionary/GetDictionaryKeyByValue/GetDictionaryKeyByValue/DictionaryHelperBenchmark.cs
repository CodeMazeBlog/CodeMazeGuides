using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Order;

namespace GetDictionaryKeyByValue;

[MemoryDiagnoser]
[HideColumns(Column.Error, Column.StdDev)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DictionaryHelperBenchmark
{
    private static readonly Dictionary<string, string> _benchmarkDict = GetDictionary();

    private readonly DictionaryHelper _dictionaryHelper = new(_benchmarkDict, "NonExistentValue");

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
    public string? UseReverseLookup()
          => _dictionaryHelper.UseReverseLookup();

    [Benchmark]
    public string? LoopThroughTheKeyValuePairs()
    => _dictionaryHelper.LoopThroughKeyValuePairs();

    [Benchmark]
    public string? LoopThroughTheKeys()
        => _dictionaryHelper.LoopThroughKeys();
}