namespace CSharp_Func_Delegate;

public class FuncDelegateWithInputParameter
{
    public double ProcessBmi(double height, double weight)
    {
        double bmi = 0d;
        if (height > 0d && weight > 0d)
        {
            var h = height / 100d;

            bmi = weight / h / h;
        }

        return bmi;
    }

}