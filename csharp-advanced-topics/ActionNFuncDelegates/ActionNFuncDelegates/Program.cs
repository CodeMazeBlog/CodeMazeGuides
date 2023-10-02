using ActionNFuncDelegates.Delegates;
using ActionNFuncDelegates.Interfaces;

IFunctionDelegate<int, int> squareDelegate = new FunctionDelegate<int, int>(SquareWrapper.Square);

// Invoke the Func delegate to calculate the square of the number
int result = squareDelegate.Execute(5);

Console.WriteLine("Square of 5 is: " + result);

// Using Action delegate
IActionDelegate<string> printMessageDelegate = new ActionDelegate<string>(PrintMessage);

//Invoke the Action delegate to print message
printMessageDelegate.Execute("Hello, Developer!");

Console.ReadLine();

//Print the given message on console
void PrintMessage(string message)
{
    Console.WriteLine("Message: " + message);
}


/// <summary>
/// Wrapper class. Has astatic function Square which returns square of a given number
/// </summary>
public class SquareWrapper
{
    /// <summary>
    /// Returns square of a number
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>    
    public static int Square(int a)
    {
        return a * a;
    }
}

