using FuncDelegates;

public class Program
{
    static void Main()
    {
        Calculation calculation = new();
        int result = calculation.Calculate(calculation.Multiply);
        Console.WriteLine($"Result is: {result}"); 
    }
}