namespace ActionAndFunc;

public class FuncDelegate
{

    public int ExecuteFuncDelegate(int num1, int num2)
    {
        Func<int, int, int> add = (a, b) => a + b;
        int result = add(num1, num2); 
        Console.WriteLine($"Result will be {result}");
        return result;
    }
}