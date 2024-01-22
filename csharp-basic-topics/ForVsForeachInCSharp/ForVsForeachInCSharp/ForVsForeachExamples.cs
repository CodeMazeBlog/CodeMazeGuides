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
    private const int size = 10000000;

    [Benchmark]
    public long ArrayUsingForeach()
    {
        var sum = 0;
        var intArray = GenerateData.GenerateRandomArray(size);

        foreach (var element in intArray)
        {
            sum += element;
        }

        return sum;
    }

    [Benchmark]
    public long ArrayUsingForLoop()
    {
        var sum = 0;
        var intArray = GenerateData.GenerateRandomArray(size);

        for (int i = 0; i < intArray.Length; i++)
        {
            sum += intArray[i];
        }

        return sum;
    }

    [Benchmark]
    public long ListUsingForeach()
    {
        var sum = 0;
        var intList = GenerateData.GenerateRandomList(size);

        foreach (var element in intList)
        {
            sum += element;
        }

        return sum;
    }

    [Benchmark]
    public long ListUsingForLoop()
    {
        var sum = 0;
        var intList = GenerateData.GenerateRandomList(size);

        for (int i = 0; i < intList.Count; i++)
        {
            sum += intList[i];
        }

        return sum;
    }

    [Benchmark]
    public long ArrayListUsingForeach()
    {
        var sum = 0;
        var arrayList = GenerateData.GenerateRandomArrayList(size);

        foreach (var element in arrayList)
        {
            sum =+ (int) element;
        }

        return sum;
    }

    [Benchmark]
    public long ArrayListUsingForLoop()
    {
        var arrayList = GenerateData.GenerateRandomArrayList(size);
        var sum = 0;

        for (int i = 0; i < arrayList.Count; i++)
        {
            sum += (int) arrayList[i];
        }

        return sum;
    }

    [Benchmark]
    public long DictionaryUsingForeach()
    {
        var sum = 0;
        var intDictionary = GenerateData.GenerateRandomDictionary(size);

        foreach (var element in intDictionary.Values)
        {
            sum += element;
        }

        return sum;
    }

    [Benchmark]
    public long DictionaryUsingForLoop()
    {
        var sum = 0;
        var intDictionary = GenerateData.GenerateRandomDictionary(size);

        for (int i = 0; i < intDictionary.Count; i++)
        {
            sum += intDictionary[i];
        }

        return sum;
    }
}