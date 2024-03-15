namespace CSharp_Func_Delegate;

public class FuncDelegateLambdaExpression
{
    public Func<double> ProcessBmiWithNoInputParametersFunc = () =>
    {
        var height = 175d;
        var weight = 75d;
        var bmi = 0d;
        if (height > 0d && weight > 0d)
        {
            var convertedheight = height / 100d;

            bmi = weight / convertedheight / convertedheight;
        }

        return bmi;
    };

    public Func<double, double, double> ProcessBmiWithInputParametersFunc = (height, weight) =>
    {
        var bmi = 0d;
        if (height > 0d && weight > 0d)
        {
            var convertedheight = height / 100d;

            bmi = weight / convertedheight / convertedheight;
        }

        return bmi;
    };
}