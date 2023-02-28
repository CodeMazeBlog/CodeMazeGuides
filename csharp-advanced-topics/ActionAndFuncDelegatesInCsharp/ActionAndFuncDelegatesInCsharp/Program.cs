using System;

namespace FuncAndDelegatesInCsharp;

//Declare a delegate that represents a method with no parameters and returns void
delegate void MyDelegate(string msg);

class Program
{
    public static void Display(string msg) => Console.WriteLine($"{msg}");

    public static int PerformAddition(int x, int y)
    {
        return x + y;
    }

    static void Main()
    {
        //Create an instance of the MyDelegate delegate
        var delegateInstance = new MyDelegate(Display);

        //Invoke the Delegate
        delegateInstance.Invoke("Simple Delegate Executed!");

        // Create an Action Delegate that point display method." 
        Action<string> actionDelegate = Display;

        // Invoke Action Delegate
        actionDelegate("Action Delegate Executed");

        //Declared a func delegate that point to PerformAddion
        Func<int, int, int> addFunc = PerformAddition;

        //Invoke the addFunc delegate by passing in two integer parameters.
        int sumofValues = addFunc(5, 10);

        Console.WriteLine("Func Delegate Executed:" + sumofValues); // Output: 15

    }
}