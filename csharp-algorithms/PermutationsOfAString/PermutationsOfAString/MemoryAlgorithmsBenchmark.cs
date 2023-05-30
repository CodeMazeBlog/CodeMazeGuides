using BenchmarkDotNet.Attributes;

namespace PermutationsOfAString
{
    [MemoryDiagnoser]
    public class MemoryAlgorithmsBenchmark
    {
        public List<byte[]> Items = new List<byte[]>
        {
            new byte[] { 0, 7, 4, 2 },
            new byte[] { 0, 7, 4, 2, 3, 6 },
            new byte[] { 0, 7, 4, 2, 3, 6, 1, 8 },
            new byte[] { 0, 7, 4, 2, 3, 6, 1, 8, 5, 9 },
        };

        [Params(0, 1, 2, 3)]
        public byte Element;

        [Benchmark]
        public void PanditasAlgorithmBenchmark()
        {
            IPermutation algorithm = new PanditasAlgorithm();
            algorithm.BenchmarkPermutations(Items[Element]);
        }

        [Benchmark]
        public void HeapsAlgorithmBenchmark()
        {
            IPermutation algorithm = new HeapsAlgorithm();
            algorithm.BenchmarkPermutations(Items[Element]);
        }
    }
}
