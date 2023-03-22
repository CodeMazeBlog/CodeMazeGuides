using static ActionAndFuncInCSharp.MethodsDefinitions;

AggregateStrings handler = GetFullName;
var result = GreetingsWithDelegate("John", "Doe", handler);

Action<string, string> act = Greeting;
act("John", "Doe");

Action<string, string> greeting = (firstName, lastName) => Console.WriteLine($"Hello from {firstName} {lastName}!");
greeting("John", "Doe");

ExtendGreeting("John", "Doe", act);

Func<int, int, long> func = Area;
var area = func(3, 5);

Func<int, int, long> areaCalculator = (width, height) => width * height;
var area2 = areaCalculator(3, 5);

var areaRecord = GetAreaAndRecord(3, 5, func);
