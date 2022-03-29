using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CompareArrays;

namespace BenchmarkRunner
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class ArrayComparerBenchmark
    {
        private static readonly ArrayComparer _arrayComparer = new();
        private static int[] _firstArray;
        private static int[] _secondArray;

        public ArrayComparerBenchmark()
        {
            FillElements(1000 * 1000);
        }

        private void FillElements(int length)
        {
            _firstArray = new int[length];
            _secondArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                var value = new Random().Next(0, 1000);
                _firstArray[i] = value;
                _secondArray[i] = value;
            }
        }

        [Benchmark]
        public void EqualityOperator()
        {
            _arrayComparer.EqualityOperator(_firstArray, _secondArray);
        }
        
        [Benchmark]
        public void ForLoop()
        {
            _arrayComparer.ForLoop(_firstArray, _secondArray);
        }        

        [Benchmark]
        public void EnumerableSequenceEqual()
        {
            _arrayComparer.EnumerableSequenceEqual(_firstArray, _secondArray);
        }

        [Benchmark]
        public void AsSpanSequenceEqual()
        {
            _arrayComparer.AsSpanSequenceEqual(_firstArray, _secondArray);
        }

        [Benchmark]
        public void EnumerableEquals()
        {
            _arrayComparer.EnumerableEquals(_firstArray, _secondArray);
        }

        [Benchmark]
        public void EnumerableReferenceEquals()
        {
            _arrayComparer.EnumerableReferenceEquals(_firstArray, _secondArray);
        }

        [Benchmark]
        public void StructuralEquatable()
        {
            _arrayComparer.StructuralEquatable(_firstArray, _secondArray);
        }
    }
}
