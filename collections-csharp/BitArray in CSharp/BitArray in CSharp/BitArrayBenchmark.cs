using BenchmarkDotNet.Attributes;
using System.Collections;

namespace BitArray_in_CSharp
{
    [MemoryDiagnoser(false)]
    public class BitArrayBenchmark
    {
        [Params(1000, 1000_000, 100_000_000)]
        public int Size { get; set; }

        [Benchmark]
        public void BitArray()
        {
            BitArray bitArray = new BitArray(Size);
            for (int i = 0; i < bitArray.Length; i++)
            {
                bitArray[i] = true;
            }
        }

        [Benchmark]
        public void BoolArray()
        {
            bool[] boolArray = new bool[Size];
            for (int i = 0; i < boolArray.Length; i++)
            {
                boolArray[i] = true;
            }
        }
    }
}
