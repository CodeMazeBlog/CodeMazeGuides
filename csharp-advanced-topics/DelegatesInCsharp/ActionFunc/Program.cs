using ActionFunc;

Console.Clear();

// Basic
Console.WriteLine($"# Basics samples {Environment.NewLine}");
var shape = new Shape();

Action<int> action = shape.Print;
action(9);

Func<int, int, int> func = shape.Compute;
Console.WriteLine($"Computed : {func(23, 45)}");

// Anonymous functions
Console.WriteLine($"{Environment.NewLine}# Anonymous functions samples {Environment.NewLine}");
Func<int, int, string> myAnonimousFunc = (a, b) => { return $"{a * b}"; };
Console.WriteLine(myAnonimousFunc(3, 9));

Action<string> myAnonymousAction = x => { Console.WriteLine($"Hello anonymous {x}"); };
myAnonymousAction("Peter");

// IEnumerable
Console.WriteLine($"{Environment.NewLine}# IEnumerable samples {Environment.NewLine}");
string[] names = { "Peter", "John", "Robert", "Lucille" };
foreach (var item in names.Select(x => x.ToUpper()))
{
    Console.WriteLine(item);
}

foreach (var item in names.Select((name, index) => $"{name} ({index})"))
{
    Console.WriteLine(item);
}