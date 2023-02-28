using ActionAndFuncDelegates;

var scores = new List<int> { 67, 54, 32, 76, 99, 65 };

Action<List<int>> action;
Console.WriteLine("----- Actions --------\n");
Console.Write("Enter 1 for the top results and anything else for the bottom: ");
var input = Console.ReadLine() ?? "";
action = input.Equals("1") ? DisplayResults.Top : DisplayResults.Bottom;
action(scores);

Func<List<int>, int> func;
Console.WriteLine("\n----- Funcs --------\n");
Console.Write("Enter 1 for the top results and anything else for the bottom: ");
input = Console.ReadLine() ?? "";
func = input.Equals("1") ? GetResults.Top : GetResults.Bottom;
Console.WriteLine(func(scores));
