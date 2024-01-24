using System.Collections;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace ForVsForeachInCSharp;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class ForVsForeachExamples
{
    private const int size = 10_000_000;
    private static readonly int[] _intArray = GenerateData.GenerateArray(size);
    private static readonly List<int> _intList = GenerateData.GenerateList(size);
    private static readonly ArrayList _arrayList = GenerateData.GenerateArrayList(size);
    private static readonly Dictionary<int, int> _intDictionary = GenerateData.GenerateDictionary(size);

    [Benchmark]
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
    public long ArrayListUsingForeach()
    {
        var sum = 0L;

        foreach (var element in _arrayList)
        {
            sum =+ (int) element;
        }

        return sum;
    }

    [Benchmark]
    public long ArrayListUsingForLoop()
    {
        var sum = 0L;

        for (int i = 0; i < _arrayList.Count; i++)
        {
            sum += (int) _arrayList[i];
        }

        return sum;
    }

    [Benchmark]
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