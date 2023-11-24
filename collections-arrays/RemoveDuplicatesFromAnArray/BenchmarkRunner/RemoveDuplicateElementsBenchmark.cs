using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using RemoveDuplicatesFromAnArray;

namespace BenchmarkRunner
{
    [RankColumn]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class RemoveDuplicateElementsBenchmark
    {
        private readonly RemoveDuplicateElements _duplicatesRemoval;
        private readonly string[] _repeatedStrArray;

        public RemoveDuplicateElementsBenchmark()
        {
            _duplicatesRemoval = new RemoveDuplicateElements();
            _repeatedStrArray = Enumerable.Repeat("it", 50).Concat(Enumerable.Repeat("jump", 80)).Concat(Enumerable.Repeat("it", 70)).ToArray();
        }

        [Benchmark]
        public void DistinctLINQMethod()
        {
            _duplicatesRemoval.WithDistinctLINQMethod(_repeatedStrArray);
        }

        [Benchmark]
        public void GroupByAndSelectLINQMethod()
        {
            _duplicatesRemoval.WithGroupByAndSelectLINQMethod(_repeatedStrArray);
        }

        [Benchmark]
        public void HashingMethod()
        {
            _duplicatesRemoval.ByHashing(_repeatedStrArray);
        }

        [Benchmark]
        public void ConversionToHashSet()
        {
            _duplicatesRemoval.ByConvertingToHashSet(_repeatedStrArray);
        }

        [Benchmark]
        public void IterationAndShifting()
        {
            _duplicatesRemoval.IterationAndShiftingElements(_repeatedStrArray);
        }

        [Benchmark]
        public void IterationAndSwapping()
        {
            _duplicatesRemoval.IterationAndSwappingElements(_repeatedStrArray);
        }
        
        [Benchmark]
        public void IterationWithDictionary()
        {
            _duplicatesRemoval.IterationWithDictionary(_repeatedStrArray);
        }
        [Benchmark]
        public void IterationWithDictionaryOpt()
        {
            _duplicatesRemoval.IterationWithDictionaryOpt(_repeatedStrArray);
        }
        [Benchmark]
        public void RecursiveMethod()
        {
            _duplicatesRemoval.RecursiveMethod(_repeatedStrArray);
        }
    }
}
