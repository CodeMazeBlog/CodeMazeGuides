// See https://aka.ms/new-console-template for more information

//Assigning methods to Action Delegates
static void SayHello(string name)
{
    Console.WriteLine($"Hello {name}");
}

Action<string> Greet = SayHello;

Greet("John Doe");

//Assigning anonymous methods to Action Delegates
Action<int, int> AddNumbers = delegate(int num1, int num2) { Console.WriteLine($"Total of {num1} + {num2} is {num1 + num2}"); };

AddNumbers(20, 32);


//Using Action Delegates with Lambda expressions
Action<string> Greetings = (name) => Console.WriteLine($"Good day, {name}.");
Greetings("John Doe");

//Assigning methods to Func Delegates
static int AddNumber(int num1, int num2)
{
    return num1 + num2;
}

Func<int, int, int> Sum = AddNumber;

Console.WriteLine(Sum(5, 8));
Console.WriteLine(Sum(32, 81));

//Assigning anonymous methods to Func Delegates
Func<int, bool> OlderThanEighteen = delegate (int age) { return age > 18; };

Console.WriteLine(OlderThanEighteen(19));
Console.WriteLine(OlderThanEighteen(8));


//Using Action Delegates with Lambda expressions
Func<string, string, string> GetFullName = (firstName, lastName) => $"Your full name is - {firstName} {lastName}";
Console.WriteLine(GetFullName("John", "Doe"));

double GetSquareRoot(int number)
{
    return Math.Sqrt(number);
}

Func<int, double> GetSquareRootFunc = GetSquareRoot;

double result = GetSquareRootFunc(25);

Console.WriteLine(result);