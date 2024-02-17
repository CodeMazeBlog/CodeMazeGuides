using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators;

public class GetItemsGenerator(IRandomGenerator randomGenerator) : IBooleanGenerator
{
    public bool NextBool() => randomGenerator.GetItems([false, true], 1)[0];
}
