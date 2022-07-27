using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConcatenateLists;

namespace BenchmarkRunner
{
    [RankColumn]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ConcatenatorBenchmark
    {
        private readonly List<string> _firstList = Enumerable.Repeat("Code", 1_000_000).ToList();
        private readonly List<string> _secondList = Enumerable.Repeat("Maze", 1_000_000).ToList();
        private readonly Concatenator _concatenator = new();
               
        [Benchmark]
        public void UsingAdd()
        {
             _concatenator.UsingAdd(_firstList, _secondList);
        }

        [Benchmark]
        public void UsingEnumerableConcat()
        {
            _concatenator.UsingEnumerableConcat(_firstList, _secondList);
        }

        [Benchmark]
        public void UsingEnumerableUnion()
        {
            _concatenator.UsingEnumerableUnion(_firstList, _secondList);
        }

        [Benchmark]
        public void UsingAddRange()
        {
            _concatenator.UsingAddRange(_firstList, _secondList);
        }

        [Benchmark]
        public void UsingCopyTo()
        {
            _concatenator.UsingCopyTo(_firstList, _secondList);
        }

        [Benchmark]
        public void UsingSelectMany()
        {
            _concatenator.UsingSelectMany(_firstList, _secondList);
        }
    }
}
