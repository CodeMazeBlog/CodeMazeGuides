using BenchmarkDotNet.Attributes;

namespace ListAllThePermutationsOfStringInCSharp
{
    [MemoryDiagnoser]
    public class MemoryAlgorithmsBenchmark
    {
        [Params(4, 6, 8)]
        public byte NumberOfItems;

        [Benchmark]
        public void BasicAlgorithmBenchmark()
        {
            IPermutation algorithm = new BasicAlgorithm();
            algorithm.BenchmarkPermutations(NumberOfItems);
        }

        [Benchmark]
        public void ImprovedAlgorithmBenchmark()
        {
            IPermutation algorithm = new ImprovedAlgorithm();
            algorithm.BenchmarkPermutations(NumberOfItems);
        }

        [Benchmark]
        public void RecursiveAlgorithmBenchmark()
        {
            IPermutation algorithm = new RecursiveAlgorithm();
            algorithm.BenchmarkPermutations(NumberOfItems);
        }

        [Benchmark]
        public void HeapsAlgorithmBenchmark()
        {
            IPermutation algorithm = new HeapsAlgorithm();
            algorithm.BenchmarkPermutations(NumberOfItems);
        }
    }
}
