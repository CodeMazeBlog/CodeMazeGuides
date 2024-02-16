using System.Buffers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;
using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BenchmarkFirstThreePlusDirectGetItems : BenchmarkBase
    {
        [Params(1_000, 1_000_000)]
        public int NumberOfBooleans { get; set; }

        [Benchmark]
        public void NextIntegerGenerator()
        {
            var generator = new NextIntegerGenerator(RandomGenerator);
            StoreEverything(generator, NumberOfBooleans);
        }

        [Benchmark]
        public void NextDoubleGenerator()
        {
            var generator = new NextDoubleGenerator(RandomGenerator);
            StoreEverything(generator, NumberOfBooleans);
        }

        [Benchmark]
        public void GetItemsGenerator()
        {
            var generator = new GetItemsGenerator(RandomGenerator);
            StoreEverything(generator, NumberOfBooleans);
        }

        [Benchmark]
        public void GetItemsDirectGenerator()
        {
            bool[]? buffer = null;
            try
            {
                buffer = ArrayPool<bool>.Shared.Rent(NumberOfBooleans);
                var bufferSpan = buffer.AsSpan(NumberOfBooleans);

                var r = new SystemRandomGenerator();
                r.GetItems([true, false], bufferSpan);
            }
            finally
            {
                if (buffer is not null)
                    ArrayPool<bool>.Shared.Return(buffer);
            }
        }
    }
}
