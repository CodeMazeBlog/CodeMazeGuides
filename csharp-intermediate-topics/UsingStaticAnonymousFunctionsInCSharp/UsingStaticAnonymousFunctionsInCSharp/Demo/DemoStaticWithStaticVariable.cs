namespace UsingStaticAnonymousFunctionsInCSharp.Demo;

// static anonymous function with static variable
public class DemoStaticWithStaticVariable
{
    private static double _numberInEnclosingScope = 4;

    void Calculate(Func<double, double> func)
    {
        Console.WriteLine(func(6));
    }

    public void Display()
    {
        Calculate(static num => Math.Pow(_numberInEnclosingScope, num));
    }
}