namespace UsingStaticAnonymousFunctionsInCSharp.Demo;

// static anonymous function with this, base, locals and parameters
public class DemoStaticDerivative : DemoStaticBase
{
    private double _numberInThis = 4;

    void Calculate(Func<double, double> func)
    {
        Console.WriteLine(func(6));
    }

    public void Display(double numberInParameter)
    {
        double numberInLocal = 2;

        // this, base, locals and parameters - can't be referenced

        // Error CS8821: A static anonymous function cannot contain a reference to 'this' or 'base'.
        //Calculate(static num => Math.Pow(this._numberInThis, num));

        // Error CS8821: A static anonymous function cannot contain a reference to 'this' or 'base'.
        //Calculate(static num => Math.Pow(base.numberInBase, num));

        // Error CS8820: A static anonymous function cannot contain a reference to 'numberInLocal'.
        //Calculate(static num => Math.Pow(numberInLocal, num));

        // Error CS8820: A static anonymous function cannot contain a reference to 'numberInParameter'.
        //Calculate(static num => Math.Pow(numberInParameter, num));
    }
}
