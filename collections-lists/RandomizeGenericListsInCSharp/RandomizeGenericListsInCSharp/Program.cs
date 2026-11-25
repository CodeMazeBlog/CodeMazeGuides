using BenchmarkDotNet.Running;
using RandomizeGenericListsInCSharp;

if (args.Length > 0)
{
    BenchmarkSwitcher.FromAssembly(typeof(RandomizeGenericListsBenchmarks).Assembly).Run(args);
    return;
}

var methods = new RandomizeGenericListsMethods();
string[] orders = ["123", "132", "213", "231", "312", "321"];

PrintCounts("Fisher-Yates", methods.CountOrders(methods.GenerateRandomLoop, 60_000));
PrintCounts("Random.Shuffle", methods.CountOrders(methods.GenerateRandomShuffle, 60_000));
PrintCounts("Biased loop", methods.CountOrders(methods.GenerateBiasedLoop, 60_000));

void PrintCounts(string name, Dictionary<string, int> counts)
{
    var line = string.Join("  ", orders.Select(o => $"{o}: {counts.GetValueOrDefault(o),6}"));
    Console.WriteLine($"{name,-15}{line}");
}
