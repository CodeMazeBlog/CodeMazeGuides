using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace ObjectComparisons
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
    public class ObjectComparisonBenchmark
    {
        [Params(10000)]
        public int Count { get; set; }

        public Employee[] Employees { get; } = new Employee[5]
        {
            new Employee(4, "John"),
            new Employee(2, "Tom"),
            new Employee(1, "Eric"),
            new Employee(5, "Dan"),
            new Employee(3, "Alen")
        };

        [Benchmark]
        public void CompareUsingIComparable()
        {
            for (int i = 0; i < Count; i++)
            {
                Array.Sort(Employees);
            }
        }

        [Benchmark]
        public void CompareUsingIComparer()
        {
            for (int i = 0; i < Count; i++)
            {
                Array.Sort(Employees, Employee.SortByIdAscending());
            }
        }

        [Benchmark]
        public void CompareUsingComparisonDelegate()
        {
            for (int i = 0; i < Count; i++)
            {
                Array.Sort(Employees, Employee.CompareEmployeesByIdAscending);
            }
        }
    }
}
