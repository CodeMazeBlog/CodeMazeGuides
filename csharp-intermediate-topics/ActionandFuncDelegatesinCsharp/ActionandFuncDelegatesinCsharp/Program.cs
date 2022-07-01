// See https://aka.ms/new-console-template for more information

//Assigning methods to Action Delegates
static void PrintName(string name)
{
    Console.WriteLine($"Hello {name}");
}

Action<string> printNameAction = PrintName;

printNameAction("John Doe");

//Assigning anonymous methods to Action Delegates
Action<int> anonymousMethodAction = delegate(int number) { Console.WriteLine($"Number passed is {number}"); };

anonymousMethodAction(20);


//Using Action Delegates with Lambda expressions
Action<string> lambdaExpressAction = (name) => Console.WriteLine($"The animal is: {name}");
lambdaExpressAction("Lion");

//Assigning methods to Func Delegates
static string PrintNameAgain(string name)
{
    return $"Hello {name}";
}

Func<string, string> funcName = PrintNameAgain;

Console.WriteLine(funcName("John Doe"));

//Assigning anonymous methods to Func Delegates
Func<string, string> anonymousFuncMethod = delegate (string name) { return $"Name passed is {name}"; };

Console.WriteLine(anonymousFuncMethod("Anonymous Func Delegates"));


//Using Action Delegates with Lambda expressions
Func<string, string, string> lambdaExpressionsFunc = (firstName, lastName) => $"Your name is {firstName} {lastName}";
Console.WriteLine(lambdaExpressionsFunc("John", "Doe"));

double GetSquareRoot(int number)
{
    return Math.Sqrt(number);
}

Func<int, double> GetSquareRootFunc = GetSquareRoot;

double result = GetSquareRootFunc(20);

Console.WriteLine(result);