using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace ForVsForeachInCSharp;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class ForVsForeachExamples
{
    private const int elementCount = 10_000_000;
    private static readonly int[] _intArray = GenerateData.GenerateArray(elementCount);
    private static readonly List<int> _intList = GenerateData.GenerateList(elementCount);
    private static readonly Dictionary<int, int> _intDictionary = GenerateData.GenerateDictionary(elementCount);

    [Benchmark]
    [BenchmarkCategory("Array")]
    public long ArrayUsingForeach()
    {
        var sum = 0L;

        foreach (var element in _intArray)
        {
            sum += element;
        }

        return sum;
    }

    [Benchmark]
    [BenchmarkCategory("Array")]
    public long ArrayUsingForLoop()
    {
        var sum = 0L;

        for (int i = 0; i < _intArray.Length; i++)
        {
            sum += _intArray[i];
        }

        return sum;
    }

    [Benchmark]
    [BenchmarkCategory("List")]
    public long ListUsingForeach()
    {
        var sum = 0L;

        foreach (var element in _intList)
        {
            sum += element;
        }

        return sum;
    }

    [Benchmark]
    [BenchmarkCategory("List")]
    public long ListUsingForLoop()
    {
        var sum = 0L;

        for (int i = 0; i < _intList.Count; i++)
        {
            sum += _intList[i];
        }

        return sum;
    }

    [Benchmark]
    [BenchmarkCategory("Dictionary")]
    public long DictionaryUsingForeach()
    {
        var sum = 0L;

        foreach (var element in _intDictionary.Values)
        {
            sum += element;
        }

        return sum;
    }

    [Benchmark]
    [BenchmarkCategory("Dictionary")]
    public long DictionaryUsingForLoop()
    {
        var sum = 0L;

        for (int i = 0; i < _intDictionary.Count; i++)
        {
            sum += _intDictionary[i];
        }

        return sum;
    }
}