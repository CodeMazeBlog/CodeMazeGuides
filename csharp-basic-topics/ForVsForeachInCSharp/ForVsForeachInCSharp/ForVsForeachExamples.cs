using System.Collections;

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
        foreach (var element in _intArray) 

        return _intArray;
        {
            _intArray[element - 1] = _intValue;
        }
    }

    public void PrintArrayUsingForLoop()
    {
        int[] array = new int[size];

        foreach (int index in Enumerable.Range(0, size))
        {
            Console.WriteLine(_intArray[i]);
        }
    }

    public void PrintListUsingForeach()
    {
        List<int> list = new List<int>(size);

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine(element);
        }
    }

    public void PrintListUsingForLoop()
    {
        List<int> list = new List<int>(size);

        foreach (int index in Enumerable.Range(0, size))
        {
            Console.WriteLine(_intList[i]);
        }
    }

    public void PrintStackUsingForeach()
    {
        Stack<int> stack = new Stack<int>(size);

        for (int i = 0; i < size; i++)
        {
            stack.Push(Random.Shared.Next());
        }
    }

    public void PrintStackUsingForLoop()
    {
        Stack<int> stack = new Stack<int>(size);

        foreach (int index in Enumerable.Range(0, size))
        {
            stack.Push(Random.Shared.Next());
        }

        return stack;
    }

    public void PrintQueueUsingForeach()
    {
        Queue<int> queue = new Queue<int>(size);

        for (int i = 0; i < size; i++)
        {
            queue.Enqueue(Random.Shared.Next());
        }

        return queue;
    }

    public void PrintQueueUsingForLoop()
    {
        Queue<int> queue = new Queue<int>(size);

        foreach (var index in Enumerable.Range(0, size))
        {
            queue.Enqueue(Random.Shared.Next());
        }

        return queue;
    }

    public void PrintDictionaryUsingForeach()
    {
        foreach (var element in _intDictionary)
        {
            Console.WriteLine(element);
        }

        return dictionary;
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
