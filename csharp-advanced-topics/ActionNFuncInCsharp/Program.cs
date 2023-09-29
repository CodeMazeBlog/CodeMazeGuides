using DelegatesDemo.Delegates;
using DelegatesDemo.Interfaces;

// Using Action delegate
IFunctionDelegate<int, int> squareDelegate = new FunctionDelegate<int, int>(Square);

// Invoke the Func delegate to calculate the square of the number
int result = squareDelegate.Execute(5);

Console.WriteLine("Square of 5 is: " + result);

// Using Action delegate
IActionDelegate<string> printMessageDelegate = new ActionDelegate<string>(PrintMessage);

//Invoke the Action delegate to print message
printMessageDelegate.Execute("Hello, Developer!");

Console.ReadLine();

// Define a Func delegate that represents a method with one parameter (int) and a return value (int)
static int Square(int a)
{
    return a * a;
}

//Print the given message on console
void PrintMessage(string message)
{
    Console.WriteLine("Message: " + message);
}
