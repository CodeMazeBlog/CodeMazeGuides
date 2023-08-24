using BenchmarkDotNet.Running;
using PermutationsOfAString;

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
        { ConsoleKey.N, DisplayNextPermutation.Run },
        { ConsoleKey.B, () => BenchmarkRunner.Run<MemoryAlgorithmsBenchmark>() },
    };
}

ConsoleKeyInfo SelectFromMenu()
{
    Console.Clear();
    Console.WriteLine("Welcome to the permutation generator\n\n");
    Console.WriteLine("Select option: \n");
    Console.WriteLine("     I   : Interactive permutations");
    Console.WriteLine("     N   : Get next permutation");
    Console.WriteLine("     B   : Benchmarks");
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
