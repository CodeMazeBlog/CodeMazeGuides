using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators
{
    public class NextIntegerGenerator(IRandomGenerator randomGenerator) : IBooleanGenerator
    {
        public bool NextBool() => randomGenerator.NextInteger(0, 2) == 0;
    }
}
