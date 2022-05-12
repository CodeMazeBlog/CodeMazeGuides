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
        private readonly string[] repeatedStrArray;

        public RemoveDuplicateElementsBenchmark()
        {
            _duplicatesRemoval = new RemoveDuplicateElements();
            repeatedStrArray = Enumerable.Repeat("it", 50).Concat(Enumerable.Repeat("jump", 80)).Concat(Enumerable.Repeat("it", 70)).ToArray();
        }

        [Benchmark]
        public void UsingDistinctLINQMethod()
        {
            _duplicatesRemoval.WithDistinctLINQMethod(repeatedStrArray);
        }

        [Benchmark]
        public void UsingGroupByAndSelectLINQMethod()
        {
            _duplicatesRemoval.WithGroupByAndSelectLINQMethod(repeatedStrArray);
        }

        [Benchmark]
        public void UsingHashingMethod()
        {
            _duplicatesRemoval.ByHashing(repeatedStrArray);
        }

        [Benchmark]
        public void UsingHashSet()
        {
            _duplicatesRemoval.ByCreatingHashSet(repeatedStrArray);
        }

        [Benchmark]
        public void UsingForLoopByShifting()
        {
            _duplicatesRemoval.UsingForLoopAndShiftingElements(repeatedStrArray);
        }

        [Benchmark]
        public void UsingForLoopWithDictionary()
        {
            _duplicatesRemoval.UsingForLoopWithDictionary(repeatedStrArray);
        }

        [Benchmark]
        public void UsingRecursion()
        {
            _duplicatesRemoval.UsingRecursion(repeatedStrArray);
        }
    }
}
