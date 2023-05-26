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
        private readonly RemoveDuplicateElements _duplicatesRemoval = new RemoveDuplicateElements();
        private int[]? _array;
        
        [Params(100, 10_000)]
        public int N { get; set; }
        
        [Params(0, 25, 50, 75, 100)]
        public int PercentDuplicates { get; set; }
        
        [GlobalSetup]
        public void GlobalSetup()
        {
            _array = ScrambleDuplicates(N, PercentDuplicates);
        }
        
        // Returns an array of N integers with MPercent duplicates
        private static int[] ScrambleDuplicates(int N, int MPercent)
        {
            // Calculate the number of duplicates to add
            var M = (int)Math.Round(N * MPercent / 100.0);

            // Create an array of N integers
            var arr = new int[N];

            // Fill the array with numbers from 1 to N
            for (var i = 0; i < N; i++)
                arr[i] = i + 1;

            // Shuffle the array using Fisher-Yates algorithm
            var rand = new Random();
            for (var i = N - 1; i > 0; i--)
            {
                var j = rand.Next(i + 1);
                var temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            // Add aprox. M duplicates to the array
            for (var i = 0; i < M; i++)
            {
                var index = rand.Next(N);
                arr[index] = arr[rand.Next(N)];
            }

            return arr;
        }

        [Benchmark]
        public void DistinctLINQMethod()
        {
            _duplicatesRemoval.WithDistinctLINQMethod(_array!);
        }

        [Benchmark]
        public void GroupByAndSelectLINQMethod()
        {
            _duplicatesRemoval.WithGroupByAndSelectLINQMethod(_array!);
        }

        [Benchmark]
        public void HashingMethod()
        {
            _duplicatesRemoval.ByHashing(_array!);
        }

        [Benchmark]
        public void ConversionToHashSet()
        {
            _duplicatesRemoval.ByConvertingToHashSet(_array!);
        }

        [Benchmark]
        public void IterationAndShifting()
        {
            _duplicatesRemoval.IterationAndShiftingElements(_array!);
        }

        [Benchmark]
        public void IterationAndSwapping()
        {
            _duplicatesRemoval.IterationAndSwappingElements(_array!);
        }
        
        [Benchmark]
        public void IterationWithDictionary()
        {
            _duplicatesRemoval.IterationWithDictionary(_array!);
        }
        [Benchmark]
        public void IterationWithDictionaryOpt()
        {
            _duplicatesRemoval.IterationWithDictionaryOpt(_array!);
        }
        [Benchmark]
        public void RecursiveMethod()
        {
            _duplicatesRemoval.RecursiveMethod(_array!);
        }
    }
}
