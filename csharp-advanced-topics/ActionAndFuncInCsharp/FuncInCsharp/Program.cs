using FuncInCsharp;

var values = new[] { 0, 10, 20 };
Foo.Recalculate(values, AddFive);

Console.WriteLine(string.Join(' ', values));

static int AddFive(int value) => value + 5;
