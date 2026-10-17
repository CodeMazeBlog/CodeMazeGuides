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
        [Params(50_000, 1_000_000)]
        public int Size;

        private List<string> _firstList = [];
        private List<string> _secondList = [];
        private readonly Concatenator _concatenator = new();

        [GlobalSetup]
        public void Setup()
        {
            _firstList = Enumerable.Range(0, Size).Select(i => $"Code{i}").ToList();
            _secondList = Enumerable.Range(0, Size).Select(i => $"Maze{i}").ToList();
        }

        [Benchmark]
        public void UsingAdd()
        {
            _concatenator.UsingAdd(_firstList, _secondList);
        }

        [Benchmark]
        public void UsingAddNoCapacity()
        {
            _concatenator.UsingAddNoCapacity(_firstList, _secondList);
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
        public void UsingAddRangeNoCapacity()
        {
            _concatenator.UsingAddRangeNoCapacity(_firstList, _secondList);
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

        [Benchmark]
        public void UsingCollectionExpression()
        {
            _concatenator.UsingCollectionExpression(_firstList, _secondList);
        }
    }
}
