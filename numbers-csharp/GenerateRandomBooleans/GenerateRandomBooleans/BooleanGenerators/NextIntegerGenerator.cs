using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators
{
    public class NextIntegerGenerator(IRandomGenerator randomGenerator) : IBooleanGenerator
    {
        private readonly IRandomGenerator _randomGenerator = randomGenerator;

        public bool NextBool() => _randomGenerator.NextInteger(0, 2) == 0;
    }
}
