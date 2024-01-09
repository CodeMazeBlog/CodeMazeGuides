using System.Collections;

namespace ForVsForeachInCSharp;

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
        _intArray = _generateData.GenerateRandomArray(10000000);
        _intList = _generateData.GenerateRandomList(10000000);
        _intStack = _generateData.GenerateRandomStack(10000000);
        _intQueue = _generateData.GenerateRandomQueue(10000000);
        _intDictionary = _generateData.GenerateRandomDictionary(10000000);
    }
    public void PrintArrayUsingForeach() 
    {
        foreach (var element in _intArray) 
        {
            Console.WriteLine(element);
        }
    }

    public void PrintArrayUsingForLoop()
    {
        for (int i = 0; i < _intArray.Length; i++)
        {
            Console.WriteLine(_intArray[i]);
        }
    }

    public void PrintListUsingForeach()
    {
        foreach (var element in _intList)
        {
            Console.WriteLine(element);
        }
    }

    public void PrintListUsingForLoop()
    {
        for (int i = 0; i < _intList.Count; i++)
        {
            Console.WriteLine(_intList[i]);
        }
    }

    public void PrintStackUsingForeach()
    {
        foreach (var element in _intStack)
        {
            Console.WriteLine(element);
        }
    }

    public void PrintStackUsingForLoop()
    {
        var array = _intStack.ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    public void PrintQueueUsingForeach()
    {
        foreach (var element in _intQueue)
        {
            Console.WriteLine(element);
        }
    }

    public void PrintQueueUsingForLoop()
    {
        var array = _intQueue.ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    public void PrintDictionaryUsingForeach()
    {
        foreach (var element in _intDictionary)
        {
            Console.WriteLine(element);
        }
    }

    //public void PrintDictionaryUsingForLoop()
    //{
    //    var array = _intQueue.ToArray();

    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        Console.WriteLine(array[i]);
    //    }
    //}
}
