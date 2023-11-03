namespace UsingStaticAnonymousFunctionsInCSharp;

// non-static anonymous function
public class DemoNonStatic
{
    private double num1 = 4;

    void Calculate(Func<double, double> func)
    {
        Console.WriteLine(func(6));
    }

    public void Display()
    {
        Calculate(num => Math.Pow(num1, num));
    }
}

// static anonymous function with const variable
public class DemoStaticWithConstVariable
{
    private const double num1 = 4;

    void Calculate(Func<double, double> func)
    {
        Console.WriteLine(func(6));
    }

    public void Display()
    {
        Calculate(static num => Math.Pow(num1, num));
    }
}

// static anonymous function with static variable
public class DemoStaticWithStaticVariable
{
    private static double num1 = 4;

    void Calculate(Func<double, double> func)
    {
        Console.WriteLine(func(6));
    }

    public void Display()
    {
        Calculate(static num => Math.Pow(num1, num));
    }
}

// static anonymous function with this, base, locals and parameters
public class DemoStaticBase
{
    public double numberInBase = 3;
}

public class DemoStaticDerivative : DemoStaticBase
{
    private double numberInThis = 4;

    void Calculate(Func<double, double> func)
    {
        Console.WriteLine(func(6)); 
    }

    public void Display(double numberInParameter)
    {
        double numberInLocal = 2;

        // this, base, locals and parameters - can't be referenced
        //Calculate(static num => Math.Pow(this.numberInThis, num));
        //Calculate(static num => Math.Pow(base.numberInBase, num));
        //Calculate(static num => Math.Pow(numberInLocal, num));
        //Calculate(static num => Math.Pow(numberInParameter, num));
    }
}

// static anonymous function with nameof
public class DemoStaticWithNameOf
{
    private double numberInThis = 4;

    void Calculate(Func<double, double> func)
    {
        Console.WriteLine(func(6));
    }

    public void Display()
    {
        double numberInLocal = 2;

        Calculate(static num => Math.Pow(Double.Parse(nameof(numberInThis)), num));        
    }
}

// static anonymous function with non-static local method
public class DemoStaticWithNonStaticLocalMethod
{
    private double numberInThis = 4;

    void Calculate(Func<double, double> func)
    {
        Console.WriteLine(func(6));
    }

    public void Display()
    {
        double numberInLocal = 2;

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
