using Delegates;

class Program
{
    public static void Main(string[] args)
    {
        Calculator calculator = new ();
        Logger logger = new ();

        calculator.CalculationPerformed += logger.LogCalculation;

        int addedResult = calculator.Add(3, 5);
        Console.WriteLine($"{addedResult}");

        int subResult = calculator.Subtract(11, 5);
        Console.WriteLine($"{subResult}");
    }
}