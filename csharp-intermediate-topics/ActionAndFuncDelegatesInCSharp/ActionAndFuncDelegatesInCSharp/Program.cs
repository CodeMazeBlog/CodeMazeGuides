using ActionAndFuncDelegatesInCSharp;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        ExecuteBasicExample();
    }

    private static void ExecuteBasicExample () { 
        var basicDelegate = new BasicDelegate();
        var inputNumber = 5;

        //Basic example delegate
        basicDelegate.Run(inputNumber);

        //Basic example action
        basicDelegate.RunAction(inputNumber);

        //Basic example func
        basicDelegate.RunFunc(inputNumber);
    }
}