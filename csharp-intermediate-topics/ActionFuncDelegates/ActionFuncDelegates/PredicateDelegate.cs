namespace ActionFuncDelegates;

public partial class Delegate
{
    public delegate bool IsEven(int num);

    bool ValidateEven(int number)
    {
        return number % 2 == 0;
    }

    public void PredicateRun()
    {
        IsEven isEven = ValidateEven;
        var result = isEven(92);
        Console.WriteLine($"[Delegate: IsEven]: {result}");
    }
}

public class PredicateDelegate
{
    public bool IsEven(int num)
    {
        return num % 2 == 0;
    }

    public bool Run()
    {
        Predicate<int> isEven = IsEven;
        var result = isEven(92);
        Console.WriteLine($"[Predicate: IsEven]: {result}");
        return result;
    }
}