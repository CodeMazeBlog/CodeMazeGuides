namespace FuncDelegate;

public class FuncSample
{
    public static int Add(int x, int y)
    {
        return x + y;
    }

    public static int Multiply(int x, int y)
    {
        return x * y;
    }

    public static void Main()
    {
        Func<int, int, int> operation = Add;
        var additionResult = operation(5, 8);
        
        operation = Multiply;
        var multiplicationResult = operation(5, 8);

        Console.WriteLine($"The result of the addition is: {additionResult} and " +
                          $"multiplication is: {multiplicationResult}");
    }
}