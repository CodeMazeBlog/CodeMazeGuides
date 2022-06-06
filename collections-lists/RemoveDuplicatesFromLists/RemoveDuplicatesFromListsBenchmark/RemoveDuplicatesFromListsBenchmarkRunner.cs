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
        private RemoveDuplicatesHelper<string> _helper = new RemoveDuplicatesHelper<string>();

        public RemoveDuplicateElementsBenchmark()
        {
            _helper.ListWithDuplicates.AddRange(Enumerable.Repeat("it", 50).Concat(Enumerable.Repeat("jump", 80)).Concat(Enumerable.Repeat("it", 70)).ToList());
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
            _helper.UsingHashSet();
        }

        [Benchmark]
        public void DictionaryMethod()
        {
            _helper.UsingDictionary();
        }

        [Benchmark]
        public void EmptyListMethod()
        {
            _helper.UsingEmptyList();
        }

        [Benchmark]
        public void IterationsMethod()
        {
            _helper.UsingIterations();
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
