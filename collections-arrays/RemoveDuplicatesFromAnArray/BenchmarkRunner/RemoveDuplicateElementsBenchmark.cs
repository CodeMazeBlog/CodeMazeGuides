using BenchmarkDotNet.Attributes;
using RemoveDuplicatesFromAnArray;

namespace BenchmarkRunner
{
    [RankColumn]
    [MemoryDiagnoser]

    public class RemoveDuplicateElementsBenchmark
    {
        public static readonly RemoveDuplicateElements _duplicatesRemoval = new RemoveDuplicateElements();

        [Benchmark]
        public void UsingDistinctMethod()
        {
            var repeatedStrArray = Enumerable.Repeat("it", 50).Concat(Enumerable.Repeat("jump", 50)).Concat(Enumerable.Repeat("it", 50)).ToArray();
            var response = _duplicatesRemoval.WithDistinct_Method(repeatedStrArray);
        }

        [Benchmark]
        public void UsingGroupByandSelect()
        {
            var repeatedStrArray = Enumerable.Repeat("it", 50).Concat(Enumerable.Repeat("jump", 50)).Concat(Enumerable.Repeat("it", 50)).ToArray();
            var response = _duplicatesRemoval.WithGroupByandSelect(repeatedStrArray);

        }

        [Benchmark]
        public void UsingHashingMethod()
        {
            var repeatedStrArray = Enumerable.Repeat("it", 50).Concat(Enumerable.Repeat("jump", 50)).Concat(Enumerable.Repeat("it", 50)).ToArray();
            var response = _duplicatesRemoval.ByHashing(repeatedStrArray);

        }

        [Benchmark]
        public void UsingHashSet()
        {
            var repeatedStrArray = Enumerable.Repeat("it", 50).Concat(Enumerable.Repeat("jump", 50)).Concat(Enumerable.Repeat("it", 50)).ToArray();
            var response = _duplicatesRemoval.ByCreatingHashSet(repeatedStrArray);
        }

        [Benchmark]
        public void UsingForLoopByShifting()
        {
            var repeatedStrArray = Enumerable.Repeat("it", 50).Concat(Enumerable.Repeat("jump", 50)).Concat(Enumerable.Repeat("it", 50)).ToArray();
            var response = _duplicatesRemoval.UsingForLoop(repeatedStrArray);
        }

        [Benchmark]
        public void UsingForLoopWithDictionary()
        {
            var repeatedStrArray = Enumerable.Repeat("it", 50).Concat(Enumerable.Repeat("jump", 50)).Concat(Enumerable.Repeat("it", 50)).ToArray();
            var response = _duplicatesRemoval.UsingForLoopWithDictionary(repeatedStrArray);
        }

        [Benchmark]
        public void UsingRecursion()
        {
            var repeatedStrArray = Enumerable.Repeat("it", 50).Concat(Enumerable.Repeat("jump", 50)).Concat(Enumerable.Repeat("it", 50)).ToArray();
            var response = _duplicatesRemoval.UsingRecursion(repeatedStrArray);
        }

    }
}
