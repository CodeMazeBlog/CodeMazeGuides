// See https://aka.ms/new-console-template for more information
using ActionAndFuncDelegatesInCSharp;

double GetRoot(double value) 
{ 
    return Math.Sqrt(value); 
}

double GetSquare(double value)
{
    return Math.Pow(value, 2);
}

void PrintRoot(double value)
{
    Console.WriteLine("The square root of {0} is {1}.", value, Math.Sqrt(value));
}

void PrintSquare(double value)
{
    Console.WriteLine("{0} squared is {1}.", value, Math.Pow(value, 2));
}

Func<double, double> getRoot = GetRoot; 
var getRoot1 = new Func<double, double>(GetRoot);
Func<double, double> getRoot2 = delegate (double value) { return Math.Sqrt(value); };
Func<double, double> getRoot3 = (double value) => Math.Sqrt(value);

Func<double, double> getSquare = GetSquare;
var getSquare1 = new Func<double, double>(GetSquare);
Func<double, double> getSquare2 = delegate (double value) { return Math.Pow(value, 2); };
Func<double, double> getSquare3 = (double value) => Math.Pow(value, 2);

Action<double> printRoot = PrintRoot;
var printRoot1 = new Action<double>(PrintRoot);
Action<double> printRoot2 = delegate (double value) { Console.WriteLine("The square root of {0} is {1}.", value, Math.Sqrt(value)); };
Action<double> printRoot3 = (double value) => Console.WriteLine("The square root of {0} is {1}.", value, Math.Sqrt(value));

Action<double> printSquare = PrintSquare;
var printSquare1 = new Action<double>(PrintSquare);
Action<double> printSquare2 = delegate (double value) { Console.WriteLine("{0} squared is {1}.", value, Math.Pow(value, 2)); };
Action<double> printSquare3 = (double value) => Console.WriteLine("{0} squared is {1}.", value, Math.Pow(value, 2));

Console.WriteLine("Enter value:");
var value = 0.0;
double.TryParse(Console.ReadLine(), out value);

Methods.GetProcessResult(value, printSquare, getSquare);
Methods.GetProcessResult(value, printRoot, getRoot);