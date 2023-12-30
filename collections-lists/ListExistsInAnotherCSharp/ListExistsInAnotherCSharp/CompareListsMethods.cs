using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;

namespace ListExistsInAnotherCSharp;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class CompareListsMethods
{
    private readonly Random _rand;

    public CompareListsMethods()
    {
        _rand = new Random();
    }

    public IEnumerable<object[]> SampleLists()
    {
        yield return new object[] 
        { 
            GenerateIntegerList(false, false, true, 10000000), 
            GenerateIntegerList(false, false, true, 10000000), 
            "Random" 
        };

        yield return new object[] 
        { 
            GenerateIntegerList(true, false, false, 10000000), 
            GenerateIntegerList(true, false, false, 10000000), 
            "Common" 
        };

        yield return new object[] 
        { 
            GenerateIntegerList(false, true, false, 10000000), 
            GenerateIntegerList(false, false, false, 10000000), 
            "Equal" 
        };
    }

    [ArgumentsSource(nameof(SampleLists))]
    [Benchmark]
    public bool CompareListUsingIntersect(List<int> firstList, List<int> secondList, string listName) 
    {
        return firstList.Intersect(secondList).Any();
    }

    [ArgumentsSource(nameof(SampleLists))]
    [Benchmark]
    public bool CompareListUsingAnyContains(List<int> firstList, List<int> secondList, string listName)
    {
        return secondList.Any(firstList.Contains);
    }

    [ArgumentsSource(nameof(SampleLists))]
    [Benchmark]
    public bool CompareListUsingIteration(List<int> firstList, List<int> secondList, string listName) 
    {
        var elementExists = false;

        foreach (var item in firstList)
        {
            if (secondList.Contains(item))
            {
                elementExists = true;
                break;
            }
        }

        return elementExists;
    }

    [ArgumentsSource(nameof(SampleLists))]
    [Benchmark]
    public bool CompareListUsingExcept(List<int> firstList, List<int> secondList, string listName)
    {
        var elementExists = false;

        var difference = secondList.Except(firstList).ToList();

        if (difference.Count == secondList.Count)
        {
            return elementExists;
        }
        else
        {
            elementExists = true;
            return elementExists;
        }
    }

    private List<int> GenerateIntegerList(bool commonElements, bool allElements, bool randomElements, int size)
    {
        var integerList = new List<int>();

        if (randomElements == true) 
        {
            for(int i = 0; i < size; i++) 
            {
                integerList.Add(_rand.Next());
            }
        }

        if (allElements == true) 
        {
            for (int i = 0; i < size; i++)
            {
                integerList.Add(i);
            }
        }

        if (commonElements == true) 
        {
            for (int i = 0; i < size/2; i++)
            {
                integerList.Add(i);
            }

            for (int i = size/2; i < size; i++)
            {
                integerList.Add(_rand.Next());
            }
        }

        return integerList;
    }
}
