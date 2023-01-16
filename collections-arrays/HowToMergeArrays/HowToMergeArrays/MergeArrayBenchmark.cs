using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace HowToMergeArrays
{
    [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class MergeArrayBenchmark
    {
        private static readonly int _arraySize = 50000;

        public int ArraySize
        {
            get { return _arraySize; }
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetSourceArrayPopulatedWithNumbers))]
        public int[] MergeUsingArrayCopyWithNewArray(int[] firstArray, int[] secondArray)
        {
            var combinedArray = new int[firstArray.Length + secondArray.Length];
            Array.Copy(firstArray, combinedArray, firstArray.Length);
            Array.Copy(secondArray, 0, combinedArray, firstArray.Length, secondArray.Length);

            return combinedArray;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetSourceArrayPopulatedWithNumbers))]
        public int[] MergeUsingArrayCopyWithResize(int[] firstArray, int[] secondArray)
        {
            var originalFirstArrayLength = firstArray.Length;
            int[] firstTempArray = Array.Empty<int>();

            Array.Resize(ref firstTempArray, firstArray.Length + secondArray.Length);
            Array.Copy(secondArray, 0, firstTempArray, originalFirstArrayLength, secondArray.Length);

            return firstTempArray;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetSourceArrayPopulatedWithNumbers))]
        public int[] MergeUsingArrayCopyTo(int[] firstArray, int[] secondArray)
        {
            var combinedArray = new int[firstArray.Length + secondArray.Length];
            firstArray.CopyTo(combinedArray, 0);
            secondArray.CopyTo(combinedArray, firstArray.Length);

            return combinedArray;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetSourceArrayPopulatedWithNumbers))]
        public int[] MergeUsingLinqConcat(int[] firstArray, int[] secondArray)
        {
            var combinedArray = firstArray.Concat(secondArray).ToArray();

            return combinedArray;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetSourceArrayPopulatedWithNumbers))]
        public int[] MergeUsingLinqUnion(int[] firstArray, int[] secondArray)
        {
            var combinedArray = firstArray.Union(secondArray).ToArray();

            return combinedArray;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetSourceArrayPopulatedWithNumbers))]
        public int[] MergeUsingLinqSelectMany(int[] firstArray, int[] secondArray)
        {
            var firstAndSecondArray = new[] { firstArray, secondArray };
            var combinedArray = firstAndSecondArray.SelectMany(animal => animal).ToArray();

            return combinedArray;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetSourceArrayPopulatedWithNumbers))]
        public int[] MergeUsingBlockCopy(int[] firstArray, int[] secondArray)
        {
            var combinedArray = new int[firstArray.Length + secondArray.Length];

            Buffer.BlockCopy(firstArray, 0, combinedArray, 0, firstArray.Length);
            Buffer.BlockCopy(secondArray, 0, combinedArray, firstArray.Length, secondArray.Length);

            return combinedArray;
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetSourceArrayPopulatedWithNumbers))]
        public int[] MergeUsingNewArrayManually(int[] firstArray, int[] secondArray)
        {
            var combinedArray = new int[firstArray.Length + secondArray.Length];
            for (int i = 0; i < combinedArray.Length; i++)
            {
                if (i >= firstArray.Length)
                {
                    combinedArray[i] = secondArray[i - firstArray.Length];
                }
                else
                {
                    combinedArray[i] = firstArray[i];
                }
            }

            return combinedArray;
        }

        // Helper methods

        public IEnumerable<object[]> GetSourceArrayPopulatedWithNumbers()
        {
            var first = Enumerable.Repeat(1, _arraySize).ToArray();
            var second = Enumerable.Repeat(2, _arraySize).ToArray();

            yield return new object[] { first, second };
        }
    }
}
