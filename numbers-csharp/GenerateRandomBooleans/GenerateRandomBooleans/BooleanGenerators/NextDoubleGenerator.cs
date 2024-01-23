using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators
{
    public class NextDoubleGenerator(IRandomGenerator randomGenerator) : IBooleanGenerator
    {
        private readonly IRandomGenerator _randomGenerator = randomGenerator;

        public bool NextBool() => _randomGenerator.NextDouble() > 0.5;
    }
}
