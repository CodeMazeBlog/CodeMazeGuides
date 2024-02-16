using System.Buffers;
using GenerateRandomBooleans.BooleanGenerators;
using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    public class BenchmarkBase
    {
        protected readonly IRandomGenerator RandomGenerator = new SystemRandomGenerator();

        protected long RoundRobin(IBooleanGenerator generator, int numberOfBooleans)
        {
            var countTrue = 0L;
            for (var i = 0; i < numberOfBooleans; i++)
            {
                if (generator.NextBool())
                    ++countTrue;
            }

            return countTrue;
        }

        protected void StoreEverything(IBooleanGenerator generator, int numberOfBooleans)
        {
            bool[]? buffer = null;
            try
            {
                buffer = ArrayPool<bool>.Shared.Rent(numberOfBooleans);
                for (var index = 0; index < numberOfBooleans; index++)
                {
                    buffer[index] = generator.NextBool();
                }
            }
            finally
            {
                if (buffer is not null)
                    ArrayPool<bool>.Shared.Return(buffer);
            }
        }
    }
}
