namespace CSharp_Func_Delegate;

public class FuncDelegateLambdaExpression
{
    public Func<double> ProcessBmiWithNoInputParametersFunc = () =>
    {
        double height = 175d;
        double weight = 75d;
        double bmi = 0d;
        if (height > 0d && weight > 0d)
        {
            var h = height / 100d;

            bmi = weight / h / h;
        }

        return bmi;
    };

    public Func<double, double, double> ProcessBmiWithInputParametersFunc = (height, weight) =>
    {
        double bmi = 0d;
        if (height > 0d && weight > 0d)
        {
            var h = height / 100d;

            bmi = weight / h / h;
        }

        return bmi;
    };
}