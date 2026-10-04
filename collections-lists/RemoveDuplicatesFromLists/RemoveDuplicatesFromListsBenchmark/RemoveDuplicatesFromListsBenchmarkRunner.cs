using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using RemoveDuplicatesFromLists;

namespace RemoveDuplicatesFromListBenchmark;

public class RemoveDuplicateFromListBenchmarkRunner
{
    [RankColumn]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class RemoveDuplicateElementsBenchmark
    {
        private const int ItemCount = 2_000;

        private readonly RemoveDuplicatesHelper<int> _helper = new RemoveDuplicatesHelper<int>();
        private List<int> _source = new List<int>();

        // Every case holds 2,000 items. Only the number of distinct values changes,
        // because that is what decides which approach wins.
        [Params(3, 100, 2_000)]
        public int DistinctValues { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random(42);
            _source = Enumerable.Range(0, ItemCount)
                .Select(i => i % DistinctValues + 1)
                .OrderBy(_ => random.Next())
                .ToList();
            _helper.ListWithDuplicates = _source;
        }

        [Benchmark]
        public List<int> DistinctLINQMethod()
        {
            return _helper.UsingDistinct();
        }

        [Benchmark]
        public List<int> GroupByLINQMethod()
        {
            return _helper.UsingGroupBy();
        }

        [Benchmark]
        public List<int> UnionLINQMethod()
        {
            return _helper.UsingUnion();
        }

        [Benchmark]
        public List<int> ConvertToHashSetMethod()
        {
            return _helper.ConvertingToHashSet();
        }

        [Benchmark]
        public List<int> InitializingHashSetMethod()
        {
            return _helper.InitializingAHashSet();
        }

        [Benchmark]
        public List<int> DictionaryMethod()
        {
            return _helper.UsingDictionary();
        }

        [Benchmark]
        public List<int> EmptyListWithContainsMethod()
        {
            return _helper.UsingEmptyListWithContains();
        }

        [Benchmark]
        public List<int> EmptyListWithAnyMethod()
        {
            return _helper.UsingEmptyListWithAny();
        }

        [Benchmark]
        public List<int> IterationsAndShiftingMethod()
        {
            return _helper.UsingIterationsAndShifting();
        }

        [Benchmark]
        public List<int> IterationsAndSwappingMethod()
        {
            return _helper.UsingIterationsAndSwapping();
        }

        [Benchmark]
        public List<int> RecursiveMethod()
        {
            return _helper.UsingRecursion();
        }

        // Sorting() and RemoveDuplicatesInPlace() change the list they work on, so these two
        // start every call from a fresh copy of the same source list. The copy is part of what they measure.
        [Benchmark]
        public List<int> SortMethod()
        {
            _helper.ListWithDuplicates = new List<int>(_source);
            return _helper.Sorting();
        }

        [Benchmark]
        public List<int> RemoveAllInPlaceMethod()
        {
            _helper.ListWithDuplicates = new List<int>(_source);
            _helper.RemoveDuplicatesInPlace();
            return _helper.ListWithDuplicates;
        }
    }
}
