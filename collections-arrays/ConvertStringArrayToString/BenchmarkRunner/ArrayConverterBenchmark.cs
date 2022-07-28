using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using StringArrayToString;

namespace BenchmarkRunner
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ArrayConverterBenchmark
    {
        private string[] _array = Enumerable.Repeat("Code-Maze", 10_000).ToArray();
        private ArrayConverter _elementConcateneator = new();

        [Benchmark]
        public void UsingLoopStringAdditionAssignment()
        {
            _elementConcateneator.UsingLoopStringAdditionAssignment(_array);
        }

        [Benchmark]
        public void UsingLoopStringBuilder()
        {
            _elementConcateneator.UsingLoopStringBuilder(_array);
        }

        [Benchmark] 
        public void UsingStringJoin()
        {
            _elementConcateneator.UsingStringJoin(_array);
        }

        [Benchmark]
        public void UsingStringConcat()
        {
            _elementConcateneator.UsingStringConcat(_array);
        }

        [Benchmark]
        public void UsingAggregation()
        {
            _elementConcateneator.UsingAggregation(_array);
        }
    }
}
