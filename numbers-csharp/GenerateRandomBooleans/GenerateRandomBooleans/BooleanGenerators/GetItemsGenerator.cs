using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators
{
    public class GetItemsGenerator(IRandomGenerator randomGenerator) : IBooleanGenerator
    {
        public bool NextBool()
        {
            Span<bool> destination = stackalloc bool[1];
            randomGenerator.GetItems([false, true], destination);

            return destination[0];
        }
    }
}
