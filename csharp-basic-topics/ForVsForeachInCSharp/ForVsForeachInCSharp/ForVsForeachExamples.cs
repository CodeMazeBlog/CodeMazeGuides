using BenchmarkDotNet.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ForVsForeachInCSharp;

public class ForVsForeachExamples
{
    private readonly GenerateData _generateData = new();
    private int[] _intArray;
    private List<int> _intList;
    private Stack<int> _intStack;
    private Queue<int> _intQueue;
    private Dictionary<int, int> _intDictionary;
    private readonly int _intValue;

    public ForVsForeachExamples() 
    {
        _intArray = _generateData.GenerateRandomArray(10000000);
        _intList = _generateData.GenerateRandomList(10000000);
        _intStack = _generateData.GenerateRandomStack(10000000);
        _intQueue = _generateData.GenerateRandomQueue(10000000);
        _intDictionary = _generateData.GenerateRandomDictionary(10000000);
        _intValue = 12345;
    }

    [Benchmark]
    public int[] PrintArrayUsingForeach() 
    {
        foreach (var element in _intArray) 
        {
            _intArray[element - 1] = _intValue;
        }

        return _intArray;
    }

    [Benchmark]
    public int[] PrintArrayUsingForLoop()
    {
        for (int i = 0; i < _intArray.Length; i++)
        {
            _intArray[i] = _intValue;
        }

        return _intArray;
    }

    [Benchmark]
    public List<int> PrintListUsingForeach()
    {
        foreach (var element in _intList)
        {
            _intList[_intList.IndexOf(element)] = _intValue;
        }

        return _intList;
    }

    [Benchmark]
    public List<int> PrintListUsingForLoop()
    {
        for (int i = 0; i < _intList.Count; i++)
        {
            _intList[i] = _intValue;
        }

        return _intList;
    }

    [Benchmark]
    public Stack<int> PrintStackUsingForeach()
    {
        foreach (var element in _intStack)
        {
            Console.WriteLine(element);
        }

        return _intStack;
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
        foreach (KeyValuePair<int, int> kvp in _intDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }

    [Benchmark]
    public void PrintDictionaryUsingForLoop()
    {
        var keysArray = new int[_intDictionary.Count];
        _intDictionary.Keys.CopyTo(keysArray, 0);

        for (int i = 0; i < keysArray.Length; i++)
        {
            var key = keysArray[i];
            var value = _intDictionary[key];
            Console.WriteLine($"Key: {key}, Value: {value}");
        }
    }
}