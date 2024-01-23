using GenerateRandomBooleans.BooleanGenerators;
using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    public class BenchmarkBase
    {
        protected readonly IRandomGenerator RandomGenerator = new SystemRandomGenerator();

        protected void RoundRobin(IBooleanGenerator generator, int NumberOfBooleans)
        {
            var bufferSize = 100;
            var result = new bool[bufferSize];
            var index = bufferSize;

            for (var i = 0; i < NumberOfBooleans; i++)
            {
                index = (index >= bufferSize - 1) ? 0 : index + 1;
                result[index] = generator.NextBool();
            }
        }

        protected void StoreEverything(IBooleanGenerator generator, int NumberOfBooleans)
        {
            var result = new bool[NumberOfBooleans];

            for (var index = 0; index < NumberOfBooleans; index++)
            {
                result[index] = generator.NextBool();
            }
        }
    }
}
