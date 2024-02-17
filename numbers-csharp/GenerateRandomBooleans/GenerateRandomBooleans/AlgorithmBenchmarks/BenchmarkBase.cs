using GenerateRandomBooleans.BooleanGenerators;
using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks;

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

    protected void StoreEverything(IBooleanGenerator generator, bool[] buffer)
    {
        for (var index = 0; index < buffer.Length; index++)
        {
            buffer[index] = generator.NextBool();
        }
    }
}
