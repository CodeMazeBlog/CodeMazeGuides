using Delegates;

public class Program
{
    public static void Main(string[] args)
    {
        Calculator calculator = new ();
        Logger logger = new ();

        calculator.CalculationPerformed += logger.LogCalculation;

        int addedResult = calculator.Add(3, 5);//delegate
        Console.WriteLine($"\n{addedResult}");

        int subResult = calculator.Subtract(11, 5);//delegate
        Console.WriteLine($"\n{subResult}");

        int productResult = calculator.Multiply(3,5);//func delegate
        Console.WriteLine($"\n{productResult}");

        Console.WriteLine("Below is an exmple of action deleagte");
        Action<string> greet = name => Console.WriteLine($"Hello, {name}!");//action delegate
        greet("Alice");
        greet("Bob");
    }
}