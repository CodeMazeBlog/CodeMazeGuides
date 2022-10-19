namespace ActionAndFuncDelegatesInCSharp;

public class Program
{
    // 1 - define a delegate
    public delegate int GraphDelegate(int x);

    // 2 - define a method that can accept another method as an argument
    public static void PlotGraph(GraphDelegate func)
    {
        for (var i = 0; i < 10; i++)
        {
            Console.WriteLine($"(x = {i}, y = {func(i)})");
        }
    }

    public static void Main(string[] args)
    {
        /**
         * 3 - assign an anonymous method to a variable of type GraphDelegate
         * We can also define a named method or a lambda expression here
         * Let's ignore lambda expression since it was introduced in .NET 3.5 along with Func and Action delegates
         */
        GraphDelegate linearGraph = delegate(int x) { return 2 * x + 3; };

        // 4 - pass the delegate as an argument
        PlotGraph(linearGraph);
    }
}