using Polly;
using RetryLogic;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Retry Logic using Action");
        Executor.Execute(FirstSimulationMethod, 3);

        Console.WriteLine();

        Console.WriteLine("Retry Logic using Func");
        var result = Executor.Execute(SecondSimulationMethod, 3);

        Console.WriteLine();

        Console.WriteLine("Retry Logic using Polly and Action");
        Policy
            .Handle<ArgumentException>()
            .Retry(3)
            .Execute(FirstSimulationMethod);

        Console.WriteLine("Retry Logic using Polly and Func");
        var resultPolly = Policy
            .Handle<ArgumentException>()
            .Retry(3)
            .Execute(SecondSimulationMethod);

        Console.WriteLine("Press <ENTER> to close the application");

        Console.ReadLine();
    }

    public static void FirstSimulationMethod()
    {
        const int forbiddenNumber = 3;

        Console.Write("Write a number: ");
        var number = int.Parse(Console.ReadLine() ?? "0");

        if (number == forbiddenNumber)
            throw new ArgumentException($"The generated number must be different from {forbiddenNumber}");

        Console.Write("Not Equal");
    }

    public static int SecondSimulationMethod()
    {
        const int forbiddenNumber = 3;

        Console.Write("Write a number: ");
        var number = int.Parse(Console.ReadLine() ?? "0");

        if (number == forbiddenNumber)
            throw new ArgumentException($"The generated number must be different from {forbiddenNumber}");

        Console.Write("Not Equal");

        return number;
    }
}
