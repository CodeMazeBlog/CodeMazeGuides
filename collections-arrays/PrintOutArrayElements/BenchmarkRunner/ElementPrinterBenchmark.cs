using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using PrintOutArrayElements;

namespace BenchmarkRunner
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class ElementPrinterBenchmark
    {
        private static readonly ElementPrinter _elementPrinter = new ();
        private static readonly int[] _array = FillElements(1_000_000);
        
        private static int[] FillElements(int length)
        {
            var array = new int[length];

            for (int i = 0; i < length; i++)
            {
                var value = new Random().Next(0, 1000);
                array[i] = value;
            }

            return array;
        }

        [Benchmark]
        public void ForLoop()
        {
            _elementPrinter.ForLoop(_array);
        }

        [Benchmark]
        public void ForeachLoop()
        {
            _elementPrinter.ForeachLoop(_array);
        }

        [Benchmark]
        public void AsSpan()
        {
            _elementPrinter.AsSpan(_array);
        }

        [Benchmark]
        public void ToListForeach()
        {
            _elementPrinter.ToListForEach(_array);
        }

        [Benchmark]
        public void StringJoin()
        {
            _elementPrinter.StringJoin(_array);
        }

        [Benchmark]
        public void ArrayForEach()
        {
            _elementPrinter.ArrayForEach(_array);
        }
    }
}
