namespace CSharp_Func_Delegate;

public class FuncDelegateWithInputParameter
{
    public double ProcessBmi(double height, double weight)
    {
        var bmi = 0d;
        if (height > 0d && weight > 0d)
        {
            var convertedheight = height / 100d;

            bmi = weight / convertedheight / convertedheight;
        }

        return bmi;
    }

}