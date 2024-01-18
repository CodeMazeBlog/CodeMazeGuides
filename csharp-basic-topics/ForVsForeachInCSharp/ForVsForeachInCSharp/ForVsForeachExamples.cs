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
    [Benchmark]
    [Arguments(10000000)]
    public int[] GenerateArrayForLoop(int size)
    {
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = Random.Shared.Next();
        }

        return array;
    }

    [Benchmark]
    [Arguments(10000000)]
    public int[] GenerateArrayForeach(int size)
    {
        int[] array = new int[size];

        foreach (int index in Enumerable.Range(0, size))
        {
            array[index] = Random.Shared.Next();
        }

        return array;
    }

    [Benchmark]
    [Arguments(10000000)]
    public List<int> GenerateRandomListForLoop(int size)
    {
        List<int> list = new List<int>(size);

        for (int i = 0; i < size; i++)
        {
            list.Add(Random.Shared.Next());
        }

        return list;
    }

    [Benchmark]
    [Arguments(10000000)]
    public List<int> GenerateListForeach(int size)
    {
        List<int> list = new List<int>(size);

        foreach (int index in Enumerable.Range(0, size))
        {
            list.Add(Random.Shared.Next());
        }

        return list;
    }

    [Benchmark]
    [Arguments(10000000)]
    public Stack<int> GenerateStackForLoop(int size)
    {
        Stack<int> stack = new Stack<int>(size);

        for (int i = 0; i < size; i++)
        {
            stack.Push(Random.Shared.Next());
        }

        return stack;
    }

    [Benchmark]
    [Arguments(10000000)]
    public Stack<int> GenerateStackForeach(int size)
    {
        Stack<int> stack = new Stack<int>(size);

        foreach (int index in Enumerable.Range(0, size))
        {
            stack.Push(Random.Shared.Next());
        }

        return stack;
    }

    [Benchmark]
    [Arguments(10000000)]
    public Queue<int> GenerateQueueForLoop(int size)
    {
        Queue<int> queue = new Queue<int>(size);

        for (int i = 0; i < size; i++)
        {
            queue.Enqueue(Random.Shared.Next());
        }

        return queue;
    }

    [Benchmark]
    [Arguments(10000000)]
    public Queue<int> GenerateQueueForeach(int size)
    {
        Queue<int> queue = new Queue<int>(size);

        foreach (var index in Enumerable.Range(0, size))
        {
            queue.Enqueue(Random.Shared.Next());
        }

        return queue;
    }

    [Benchmark]
    [Arguments(10000000)]
    public Dictionary<int, int> GenerateDictionaryForLoop(int size)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>(size);

        for (int i = 0; i < size; i++)
        {
            dictionary.Add(i, Random.Shared.Next());
        }

        return dictionary;
    }

    [Benchmark]
    [Arguments(10000000)]
    public Dictionary<int, int> GenerateDictionaryForeach(int size)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>(size);

        foreach (int index in Enumerable.Range(0, size))
        {
            dictionary.Add(index, Random.Shared.Next());
        }

        return dictionary;
    }
}