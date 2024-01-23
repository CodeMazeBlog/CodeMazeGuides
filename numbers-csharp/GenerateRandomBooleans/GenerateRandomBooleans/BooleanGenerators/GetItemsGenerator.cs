using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators
{
    public class GetItemsGenerator(IRandomGenerator randomGenerator) : IBooleanGenerator
    {
        private readonly IRandomGenerator _randomGenerator = randomGenerator;

        public bool NextBool() => _randomGenerator.GetItems([false, true], 1)[0];
    }
}
