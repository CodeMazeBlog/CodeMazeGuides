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
        private RemoveDuplicatesHelper<int> _helper = new RemoveDuplicatesHelper<int>();

        public RemoveDuplicateElementsBenchmark()
        {
            _helper.ListWithDuplicates.AddRange(Enumerable.Repeat(1, 50).Concat(Enumerable.Repeat(2, 80)).Concat(Enumerable.Repeat(3, 70)).ToList());
        }

        [Benchmark]
        public void DistinctLINQMethod()
        {
            _helper.UsingDistinct();
        }

        [Benchmark]
        public void GroupByLINQMethod()
        {
            _helper.UsingGroupBy();
        }

        [Benchmark]
        public void UnionLINQMethod()
        {
            _helper.UsingUnion();
        }

        [Benchmark]
        public void HashSetMethod()
        {
            _helper.ConvertingToHashSet();
        }

        [Benchmark]
        public void InitializingHashetMethod()
        {
            _helper.InitializingAHashSet();
        }

        [Benchmark]
        public void DictionaryMethod()
        {
            _helper.UsingDictionary();
        }

        [Benchmark]
        public void EmptyListWithContainsMethod()
        {
            _helper.UsingEmptyListWithContains();
        }

        [Benchmark]
        public void EmptyListWithAnyMethod()
        {
            _helper.UsingEmptyListWithAny();
        }

        [Benchmark]
        public void IterationsAndShiftingMethod()
        {
            _helper.UsingIterationsAndShifting();
        }

        [Benchmark]
        public void IterationsAndSwappingMethod()
        {
            _helper.UsingIterationsAndSwapping();
        }

        [Benchmark]
        public void RecursiveMethod()
        {
            _helper.UsingRecursion();
        }

        [Benchmark]
        public void SortMethod()
        {
            _helper.Sorting();
        }
    }
}