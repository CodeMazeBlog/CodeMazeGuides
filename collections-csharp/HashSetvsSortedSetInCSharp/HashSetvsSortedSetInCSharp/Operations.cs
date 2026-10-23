using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace HashSetvsSortedSetInCSharp;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Operations
{
    private readonly List<int> _numList;
    private readonly HashSet<int> _hashSet;
    private readonly SortedSet<int> _sortedSet;
    private readonly int _searchValue;
    private HashSet<int> _hashSetCopy = [];
    private SortedSet<int> _sortedSetCopy = [];

    public Operations()
    {
        _numList = RandomInts(1000000);
        _hashSet = InitializeIntHashSet();
        _sortedSet = InitializeIntSortedSet();
        _searchValue = int.MaxValue - 1;
    }

    [Benchmark]
    public HashSet<int> InitializeIntHashSet()
    {
        var hashSet = new HashSet<int>();

        foreach (var number in _numList)
        {
            hashSet.Add(number);
        }

        return hashSet;
    }

    [Benchmark]
    public SortedSet<int> InitializeIntSortedSet()
    {
        var sortedSet = new SortedSet<int>();

        foreach (var number in _numList)
        {
            sortedSet.Add(number);
        }

        return sortedSet;
    }

    [Benchmark]
    public HashSet<int> RemoveElementFromHashSet()
    {
        _hashSet.Remove(_searchValue);

        return _hashSet;
    }

    [Benchmark]
    public SortedSet<int> RemoveElementFromSortedSet()
    {
        _sortedSet.Remove(_searchValue);

        return _sortedSet;
    }

    [IterationSetup(Targets = [nameof(RemoveWhereFromHashSet), nameof(RemoveWhereFromSortedSet)])]
    public void CopySets()
    {
        _hashSetCopy = new HashSet<int>(_hashSet);
        _sortedSetCopy = new SortedSet<int>(_sortedSet);
    }

    [Benchmark]
    public HashSet<int> RemoveWhereFromHashSet()
    {
        _hashSetCopy.RemoveWhere(IsOdd);

        return _hashSetCopy;
    }

    [Benchmark]
    public SortedSet<int> RemoveWhereFromSortedSet()
    {
        _sortedSetCopy.RemoveWhere(IsOdd);

        return _sortedSetCopy;
    }

    [Benchmark]
    public bool SearchSortedSet()
    {
        return _sortedSet.Contains(_searchValue);
    }

    [Benchmark]
    public bool SearchHashSet()
    {
        return _hashSet.Contains(_searchValue);
    }

    [Benchmark]
    public List<int> SortHashSetElements()
    {
        return _hashSet.Order().ToList();
    }

    [Benchmark]
    public List<int> SortSortedSetElements()
    {
        return _sortedSet.ToList();
    }

    private static List<int> RandomInts(int size)
    {
        var rand = new Random();
        List<int> numbers = [];

        for (int i = 0; i < size - 1; i++)
        {
            numbers.Add(rand.Next());
        }

        numbers.Add(int.MaxValue - 1);

        return numbers;
    }

    private static bool IsOdd(int num)
    {
        return num % 2 == 1;
    }
}
