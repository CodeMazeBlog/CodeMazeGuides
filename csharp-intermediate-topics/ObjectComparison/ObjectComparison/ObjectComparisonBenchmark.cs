using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace ObjectComparisons;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class ObjectComparisonBenchmark
{
    private Employee[] _source = [];
    private Employee[] _employees = [];

    [Params(5, 1_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var ids = Enumerable.Range(1, Size).ToArray();
        new Random(42).Shuffle(ids);

        _source = ids.Select(id => new Employee(id, $"Employee {id}")).ToArray();
        _employees = new Employee[Size];
    }

    [Benchmark]
    public Employee[] CompareUsingIComparable()
    {
        _source.CopyTo(_employees, 0);
        Array.Sort(_employees);

        return _employees;
    }

    [Benchmark]
    public Employee[] CompareUsingIComparer()
    {
        _source.CopyTo(_employees, 0);
        Array.Sort(_employees, Employee.SortByIdAscending());

        return _employees;
    }

    [Benchmark]
    public Employee[] CompareUsingComparisonDelegate()
    {
        _source.CopyTo(_employees, 0);
        Array.Sort(_employees, Employee.CompareEmployeesByIdAscending);

        return _employees;
    }
}
