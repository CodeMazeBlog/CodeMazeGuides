using BenchmarkDotNet.Running;
using ListAllThePermutationsOfStringInCSharp;

Dictionary<ConsoleKey, Action> keyToAction = Init();
ConsoleKeyInfo pressedKey;
do
{
    pressedKey = SelectFromMenu();
}
while (Execute(pressedKey));


static Dictionary<ConsoleKey, Action> Init()
{
    return new Dictionary<ConsoleKey, Action>
    {
        { ConsoleKey.I, InteractivePermutations.Run },
        { ConsoleKey.B, () => BenchmarkRunner.Run<MemoryAlgorithmsBenchmark>() },
        { ConsoleKey.D1, ExamplesFromTheArticle.PrintAllPossiblePositions },
        { ConsoleKey.D2, ExamplesFromTheArticle.PrintPermutations },
        { ConsoleKey.D3, ExamplesFromTheArticle.PrintPermutationsImproved },
        { ConsoleKey.D4, ExamplesFromTheArticle.PrintPermutationsRecursively },
    };
}

ConsoleKeyInfo SelectFromMenu()
{
    Console.Clear();
    Console.WriteLine("Welcome to the permutation generator\n\n");
    Console.WriteLine("Select option: \n");
    Console.WriteLine("     I   : Interactive permutations");
    Console.WriteLine("     B   : Benchmarks");
    Console.WriteLine("     1   : From the article - all possible positions");
    Console.WriteLine("     2   : From the article - permutations");
    Console.WriteLine("     3   : From the article - improved permutations");
    Console.WriteLine("     4   : From the article - recursive algorithm");
    Console.WriteLine("  <other>: Exit");

    Console.Write("\n Your selection ... ");
    var key = Console.ReadKey();
    Console.Clear();

    return key;
}

bool Execute(ConsoleKeyInfo key)
{
    if (!keyToAction.TryGetValue(key.Key, out var action))
        return false;

    action();
    Wait();

    return true;
}

void Wait()
{
    Console.WriteLine("\n\nPress any key to continue ...");
    Console.ReadKey();
}
