// See https://aka.ms/new-console-template for more information
using ActionAndFuncDelegatesInCsharp;

var operations = new Operations();
//Action with no in-parameters
Action sayHiDelegate = operations.SayHi;
sayHiDelegate();

//Action with in-parameters
Action<string, string> sayHiToFullName = operations.SayHiToFullName;
sayHiToFullName("Teri", "Dactyl");

//Action with anonyoums Functions
Action sayHelloWorld = delegate () { Console.WriteLine("Hello, World!"); };
sayHelloWorld();

//Action with lambda expression
Action<string> sayHiToName = (string name) => { Console.WriteLine($"Hi, {name}"); };
sayHiToName("Olive");

//Func with no in-parameters
Func<string> getNameDelegate = operations.GetName;
Console.WriteLine(getNameDelegate());

//Func with in-parameters
Func<int, int, int> SumDelegate = operations.Sum;
Console.WriteLine(SumDelegate(3, 2));

//Func with anonymous Function
Func<int, int, int> multiplyDelegate = delegate (int x, int y) { return x * y; };
Console.WriteLine(multiplyDelegate(3, 2));

//Func with lambda expression
Func<int, int, int> subtractDelegate = (int x, int y) => x - y;
Console.WriteLine(subtractDelegate(3, 2));



