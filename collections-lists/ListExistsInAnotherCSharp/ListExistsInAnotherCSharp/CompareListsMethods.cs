using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace ListExistsInAnotherCSharp;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class CompareListsMethods
{
    public IEnumerable<object[]> SampleLists()
    {
        yield return new object[]
        {
            GenerateIntegerList(false, false, 0, 1000000),
            GenerateIntegerList(true, false, 0, 1000000),
            "Reversed"
        };

        yield return new object[]
        {
            GenerateIntegerList(false, false, 0, 1000000),
            GenerateIntegerList(false, false, 1000001, 1000000),
            "Exclusive"
        };

        yield return new object[]
        {
            GenerateIntegerList(false, false, 0, 1000000),
            GenerateIntegerList(false, true, 1000001, 1000000),
            "Middle"
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
        foreach (var item in firstList)
        {
            if (secondList.Contains(item))
            {
                return true;
            }
        }

        return false;
    }

    [ArgumentsSource(nameof(SampleLists))]
    [Benchmark]
    public bool CompareListUsingExcept(List<int> firstList, List<int> secondList, string listName)
    {
        return secondList.Except(firstList).Count() != secondList.Count;
    }

    [ArgumentsSource(nameof(SampleLists))]
    [Benchmark]
    public bool CompareListUsingWhereAny(List<int> firstList, List<int> secondList, string listName)
    {
        return secondList.Where(firstList.Contains).Any();
    }

    public List<int> GenerateIntegerList(bool useReverse, bool useMiddle, int startIndex, int size)
    {
        var integerList = new List<int>(size);
        var i = 0;

        while(i < size) 
        { 
            integerList.Add(startIndex);
            startIndex++;
            i++;
        }

        if (useReverse)
        {
            integerList.Reverse();
        }

        if (useMiddle)
        {
            var middleElement = size / 2;

            integerList[middleElement] = middleElement;
        }

        return integerList;
    }
}