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

    private List<int> GenerateIntegerList(bool useCommonElements, bool useAllElements, bool useRandomElements, int size)
    {
        var integerList = new List<int>(size);

        if (useRandomElements) 
        {
            for(int i = 0; i < size; i++) 
            {
                integerList.Add(Random.Shared.Next());
            }
        }

        if (useAllElements) 
        {
            for (int i = 0; i < size; i++)
            {
                integerList.Add(i);
            }
        }

        if (useCommonElements) 
        {
            for (int i = 0; i < size/2; i++)
            {
                integerList.Add(i);
            }

            for (int i = size/2; i < size; i++)
            {
                integerList.Add(Random.Shared.Next());
            }
        }

        return integerList;
    }
}
