using GenerateRandomBooleans.BooleanGenerators;
using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans;

public static class FairnessTest
{
    public static void Test()
    {
        var randomGenerator = new SystemRandomGenerator();
        var booleanGenerators = new Dictionary<string, IBooleanGenerator>()
        {
            { "GetItemsGenerator", new GetItemsGenerator(randomGenerator) },
            { "GetItemsWithBufferGenerator", new GetItemsWithBufferGenerator(randomGenerator, 64) },
            { "NextDoubleGenerator", new NextDoubleGenerator(randomGenerator) },
            { "NextIntegerGenerator", new NextIntegerGenerator(randomGenerator) },
            { "NextIntegerBitsGenerator", new NextIntegerBitsGenerator(randomGenerator) },
            { "NextLongBitsGenerator", new NextLongBitsGenerator(randomGenerator) },
        };

        var numberOfBooleans = 10_000_000;
        Console.WriteLine($"{"Generator",30}: {"true",7} / {"False",7} | From the middle");
        foreach (var booleanGenerator in booleanGenerators)
        {
            var numberOfTrue = 0;
            var numberOfFalse = 0;

            foreach (var boolResult in Enumerable.Range(0, numberOfBooleans)
                                  .Select(_ => booleanGenerator.Value.NextBool()))
            {
                numberOfTrue += boolResult ? 1 : 0;
                numberOfFalse += boolResult ? 0 : 1;
            }

            var fromTheMiddle = Math.Abs(numberOfTrue - numberOfFalse) / (double)numberOfBooleans;
            Console.WriteLine($"{booleanGenerator.Key,30}: {numberOfTrue,7} / {numberOfFalse,7} | {fromTheMiddle:F7}");
        }
    }
}
