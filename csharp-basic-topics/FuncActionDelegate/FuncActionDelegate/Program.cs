public class Program
{
    public static void Main(string[] args)
    {        
        Func<int, int, int> add = (x, y) => x + y;
        int result = AddNumbers(5, 3, add);
        Console.WriteLine($"Result of addition using Func delegate: {result}");

        PerformAction(() => Console.WriteLine("Action delegate called!"));
    }
    public static int AddNumbers(int a, int b, Func<int, int, int> addFunc)
    {
        return addFunc(a, b);
    }

    public static void PerformAction(Action action)
    {
        action();
    }
}