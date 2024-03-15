namespace UsingStaticAnonymousFunctionsInCSharp.Demo;

// static anonymous function with non-static local method
public class DemoStaticWithNonStaticLocalMethod
{
    void Calculate(Func<double, double> func)
    {
        Console.WriteLine(func(6));
    }

    public void Display()
    {
        Calculate(static num =>
        {
            double numberInStatic = 5;

            double AddNumbers()
            {
                return num + numberInStatic;
            }

            return Math.Pow(AddNumbers(), 2);
        });
    }
}
