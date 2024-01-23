using BenchmarkDotNet.Running;
using GenerateRandomBooleans;
using GenerateRandomBooleans.AlgorithmBenchmarks;

var menuItems = new List<MenuItem>
{
    new("1", "Compare two random generators",
        () => BenchmarkRunner.Run<BenchmarkRandomGenerators>()),
    new("2", "Compare first three generators from the article",
        () => BenchmarkRunner.Run<BenchmarkFirstThreeGenerators>()),
    new("3", "Compare first three generators and direct GetItems()",
        () => BenchmarkRunner.Run<BenchmarkFirstThreePlusDirectGetItems>()),
    new("4", "Benchmark GetItemsWithBufferGenerator",
        () => BenchmarkRunner.Run<BenchmarkGetItemsWithBufferGenerator>()),
    new("5", "Compare GetItemsWithBufferGenerator and NextIntegerGenerator",
        () => BenchmarkRunner.Run<BenchmarkGetItemsWithBufferGeneratorVsNextIntegerGenerator>()),
    new("6", "Compare NextIntegerBitsGenerator and NextIntegerGenerator",
        () => BenchmarkRunner.Run<BenchmarkNextIntegerBitsGeneratorVsNextIntegerGenerator>()),
    new("7", "Benchmark NextBytesGenerator",
        () => BenchmarkRunner.Run<BenchmarkNextBytesGenerator>()),
    new("8", "Compare NextBytesGenerator and NextIntegerBitsGenerator",
        () => BenchmarkRunner.Run<BenchmarkNextBytesGeneratorVsNextIntegerBitsGenerator>()),
    new("9", "Compare NextIntegerBitsGenerator and NextLongBitsGenerator",
        () => BenchmarkRunner.Run<BenchmarkNextIntegerBitsGeneratorVsNextLongBitsGenerator>()),
    new("10", "Check Fairness of the tests",
        () => FairnessTest.Test()),
    new("X", "Exit",
        () => Environment.Exit(0))
};

while (true)
{
    Console.Clear();
    menuItems.ForEach(item => Console.WriteLine($"{item.Key,2}: {item.Caption}"));
    Console.WriteLine("---------------------------------------");
    Console.Write("Select option ... ");

    var input = Console.ReadLine()?.ToUpper();
    var selectedMenuItem = menuItems.Find(item => item.Key == input);

    if (selectedMenuItem != null)
    {
        selectedMenuItem.Action();
    }
    else
    {
        Console.WriteLine("Invalid option. Please try again.");
    }

    Console.WriteLine("Press any key to continue... ");
    _ = Console.ReadKey();
}

public record MenuItem(
    string Key,
    string Caption,
    Action Action
);