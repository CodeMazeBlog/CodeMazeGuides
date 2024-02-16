using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators
{
    public class NextDoubleGenerator(IRandomGenerator randomGenerator) : IBooleanGenerator
    {
        public bool NextBool() => randomGenerator.NextDouble() > 0.5;
    }
}
