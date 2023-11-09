using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace PermutationsOfAString
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class MemoryAlgorithmsBenchmark
    {
        public List<byte[]> Values = new List<byte[]>
        {
            new byte[] { 0, 7, 4, 2 },
            new byte[] { 0, 7, 4, 2, 3, 6 },
            new byte[] { 0, 7, 4, 2, 3, 6, 1, 8 },
            new byte[] { 0, 7, 4, 2, 3, 6, 1, 8, 5, 9 },
        };

        [Params(4, 6, 8, 10)]
        public int Items;

        [Benchmark]
        public void PanditasAlgorithmBenchmark()
        {
            IPermutation algorithm = new PanditasAlgorithm();
            algorithm.BenchmarkPermutations(Values[(Items - 4) / 2]);
        }

        [Benchmark]
        public void HeapsAlgorithmBenchmark()
        {
            IPermutation algorithm = new HeapsAlgorithm();
            algorithm.BenchmarkPermutations(Values[(Items - 4) / 2]);
        }

        private Byte[] GetArray(int items)
        {
            items = items - 1;
            return (items == 0) 
                ? Values[0]
                : Values[items];
        }
    }
}
