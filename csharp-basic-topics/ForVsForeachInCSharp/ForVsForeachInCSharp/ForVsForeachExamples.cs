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
    private readonly GenerateData _generateData = new();
    private readonly int[] _intArray;
    private readonly List<int> _intList;
    private readonly Stack<int> _intStack;
    private readonly Queue<int> _intQueue;
    private readonly Dictionary<int, int> _intDictionary;

    public ForVsForeachExamples()
    {
        _intArray = _generateData.GenerateRandomArray(100000);
        _intList = _generateData.GenerateRandomList(100000);
        _intStack = _generateData.GenerateRandomStack(100000);
        _intQueue = _generateData.GenerateRandomQueue(100000);
        _intDictionary = _generateData.GenerateRandomDictionary(100000);
    }

    [Benchmark]
    public void PrintArrayUsingForeach()
    {
        foreach (var element in _intArray)
        {
            Console.WriteLine(element);
        }
    }

    [Benchmark]
    public void PrintArrayUsingForLoop()
    {
        for (int i = 0; i < _intArray.Length; i++)
        {
            Console.WriteLine(_intArray[i]);
        }
    }

    [Benchmark]
    public void PrintListUsingForeach()
    {
        foreach (var element in _intList)
        {
            Console.WriteLine(element);
        }
    }

    [Benchmark]
    public void PrintListUsingForLoop()
    {
        for (int i = 0; i < _intList.Count; i++)
        {
            Console.WriteLine(_intList[i]);
        }
    }

    [Benchmark]
    public void PrintStackUsingForeach()
    {
        foreach (var element in _intStack)
        {
            Console.WriteLine(element);
        }
    }

    [Benchmark]
    public void PrintStackUsingForLoop()
    {
        var array = _intStack.ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    [Benchmark]
    public void PrintQueueUsingForeach()
    {
        foreach (var element in _intQueue)
        {
            Console.WriteLine(element);
        }
    }

    [Benchmark]
    public void PrintQueueUsingForLoop()
    {
        var array = _intQueue.ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    [Benchmark]
    public void PrintDictionaryUsingForeach()
    {
        foreach (var element in _intDictionary)
        {
            Console.WriteLine($"Key: {element.Key}, Value: {element.Value}");
        }
    }

    [Benchmark]
    public void PrintDictionaryUsingForLoop()
    {
        for (int i = 0; i < _intDictionary.Count; i++)
        {
            var key = _intDictionary.Keys.ElementAt(i);
            var value = _intDictionary[key];

            Console.WriteLine($"Key: {key}, Value: {value}");
        }
    }
}