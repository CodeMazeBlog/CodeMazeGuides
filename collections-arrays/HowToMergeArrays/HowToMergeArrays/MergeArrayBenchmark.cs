using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace HowToMergeArrays
{
    [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class MergeArrayBenchmark
    {
        private static readonly int _arraySize = 50000;

        [Benchmark]
        public int[] MergeUsingArrayCopyWithNewArray()
        {
            var firstArray = GetSourceArrayPopulatedWithNumber(1);
            var secondArray = GetSourceArrayPopulatedWithNumber(2);

            var combinedArray = new int[firstArray.Length + secondArray.Length];
            Array.Copy(firstArray, combinedArray, firstArray.Length);
            Array.Copy(secondArray, 0, combinedArray, firstArray.Length, secondArray.Length);

            return combinedArray;
        }

        [Benchmark]
        public int[] MergeUsingArrayCopyWithResize()
        {
            var firstArray = GetSourceArrayPopulatedWithNumber(1);
            var secondArray = GetSourceArrayPopulatedWithNumber(2);

            var originalFirstArrayLength = firstArray.Length;

            Array.Resize(ref firstArray, firstArray.Length + secondArray.Length);
            Array.Copy(secondArray, 0, firstArray, originalFirstArrayLength, secondArray.Length);

            return firstArray;
        }

        [Benchmark]
        public int[] MergeUsingArrayCopyTo()
        {
            var firstArray = GetSourceArrayPopulatedWithNumber(1);
            var secondArray = GetSourceArrayPopulatedWithNumber(2);

            var combinedArray = new int[firstArray.Length + secondArray.Length];
            firstArray.CopyTo(combinedArray, 0);
            secondArray.CopyTo(combinedArray, firstArray.Length);

            return combinedArray;
        }

        [Benchmark]
        public int[] MergeUsingLinqConcat()
        {
            var firstArray = GetSourceArrayPopulatedWithNumber(1);
            var secondArray = GetSourceArrayPopulatedWithNumber(2);

            var combinedArray = firstArray.Concat(secondArray).ToArray();
            return combinedArray;
        }

        [Benchmark]
        public int[] MergeUsingLinqUnion()
        {
            var firstArray = GetSourceArrayPopulatedWithNumber(1);
            var secondArray = GetSourceArrayPopulatedWithNumber(2);

            var combinedArray = firstArray.Union(secondArray).ToArray();
            return combinedArray;
        }

        [Benchmark]
        public int[] MergeUsingLinqSelectMany()
        {
            var firstArray = GetSourceArrayPopulatedWithNumber(1);
            var secondArray = GetSourceArrayPopulatedWithNumber(2);

            var firstAndSecondArray = new[] { firstArray, secondArray };
            var combinedArray = firstAndSecondArray.SelectMany(animal => animal).ToArray();
            return combinedArray;
        }

        [Benchmark]
        public int[] MergeUsingBlockCopy()
        {
            var firstArray = GetSourceArrayPopulatedWithNumber(1);
            var secondArray = GetSourceArrayPopulatedWithNumber(2);

            var combinedArray = new int[firstArray.Length + secondArray.Length];

            Buffer.BlockCopy(firstArray, 0, combinedArray, 0, firstArray.Length);
            Buffer.BlockCopy(secondArray, 0, combinedArray, firstArray.Length, secondArray.Length);

            return combinedArray;
        }

        [Benchmark]
        public int[] MergeUsingNewArrayManually()
        {
            var firstArray = GetSourceArrayPopulatedWithNumber(1);
            var secondArray = GetSourceArrayPopulatedWithNumber(2);

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

        private static int[] GetSourceArrayPopulatedWithNumber(int number)
        {
            return Enumerable.Repeat(number, _arraySize).ToArray();
        }
    }
}
