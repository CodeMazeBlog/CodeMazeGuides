/// <summary>
/// Demo Implementation of: Action<T> and Func<T>
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        //Define an Action and point it to FunctionA
        Action<string, string> funAHandle = FunctionA;
        funAHandle("CodeMaze", "Blog");

        //Define a Func and point it to FunctionB
        Func<string, string, bool> funBHandle = FunctionB;
        funBHandle("CodeMaze", "Blog");

        //Pass an Action<T> to another function as a lambda
        FunctionC((string textA, string textB) =>
        {
            Console.WriteLine("");
        });
    }

    /// <summary>
    /// This method is a procedure (Without return type)
    /// </summary>
    /// <param name="textA"></param>
    /// <param name="textB"></param>
    public static void FunctionA(string textA, string textB)
    {
        Console.WriteLine($"Hello {textA} {textB}");
    }

    /// <summary>
    /// This method is a function (With return type)
    /// </summary>
    /// <param name="textA"></param>
    /// <param name="textB"></param>
    /// <returns></returns>
    public static bool FunctionB(string textA, string textB)
    {
        Console.WriteLine($"Hello {textA} {textB}");
        return true;
    }

    /// <summary>
    /// Function that can accept another function as argument
    /// </summary>
    /// <param name="function"></param>
    public static void FunctionC(Action<string, string> function)
    {
        function("CodeMaze", "Blog");
    }
}