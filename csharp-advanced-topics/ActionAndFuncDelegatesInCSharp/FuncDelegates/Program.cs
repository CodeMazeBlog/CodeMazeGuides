public class Calculation
{
    public int Calculate(Func<int, int, int> operation)
    {
        return operation(20, 10);
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }
}

public class Program
{
    static void Main()
    {
        Calculation calculation = new();
        int result = calculation.Calculate(calculation.Multiply);
        Console.WriteLine($"Result is: {result}"); 
    }
}