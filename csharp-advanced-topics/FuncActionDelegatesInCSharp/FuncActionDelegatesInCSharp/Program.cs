using FuncActionDelegatesInCSharp;

public class Program
{
    static void Main()
    {
        //Action delegate example
        var ade = new ActionDelegateExample();
        ade.RunActionDelegateExample();

        //Func delegate example
        var fde = new FuncDelegateExample();
        fde.RunFuncDelegateExample();

        //Anonymous methods for action delegate
        Action<string> printMessageAction = m => Console.WriteLine("Your message to print:" + m);
        printMessageAction("CodeMaze is a great resource.");

        //Anonymous function for func delegate
        Action<string> printMessageFunc = delegate (string m) { Console.WriteLine(m); }; 
        printMessageFunc("CodeMaze is a great resource for info on Actionc delegates in C#");

        //Lambda expression for action delegate
        Action<string> printMessage = m => Console.WriteLine("Your message to print:" + m); 
        printMessage("CodeMaze is a great resource.");

        //Lambda expression for func delegate
        Func<string> getMessage = delegate () { return "CodeMaze is a great resource for info on Func delegates in C#"; };


    }
}