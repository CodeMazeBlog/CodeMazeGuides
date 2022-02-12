using ActionAndFuncDelegatesInCsharp;

var operations = new Operations();

Action sayHiDelegate = operations.SayHi;
sayHiDelegate();

Action<string, string> sayHiToFullName = operations.SayHiToFullName;
sayHiToFullName("Teri", "Dactyl");

Action sayHelloWorld = delegate () { Console.WriteLine("Hello, World!"); };
sayHelloWorld();

Action<string> sayHiToName = (string name) => { Console.WriteLine($"Hi, {name}"); };
sayHiToName("Olive");

Func<string> getNameDelegate = operations.GetName;
Console.WriteLine(getNameDelegate());

Func<int, int, int> SumDelegate = operations.Sum;
Console.WriteLine(SumDelegate(3, 2));

Func<int, int, int> multiplyDelegate = delegate (int x, int y) { return x * y; };
Console.WriteLine(multiplyDelegate(3, 2));

Func<int, int, int> subtractDelegate = (int x, int y) => x - y;
Console.WriteLine(subtractDelegate(3, 2));



