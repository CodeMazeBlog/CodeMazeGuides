namespace FloatingPointTypes;

public class FloatingPointArithmetic
{
    public bool FloatSumAndMultiplication(float firstValue, float secondValue, int factor)
    {
        float sum = 0F;

        for (var i = 0; i < factor; i++)
        {
            sum += firstValue + secondValue;
        }

        float product = (firstValue + secondValue) * factor;

        return sum == product;
    }


    public bool DoubleSumAndMultiplication(double firstValue, double secondValue, int factor)
    {
        double sum = 0D;

        for (var i = 0; i < factor; i++)
        {
            sum += firstValue + secondValue;
        }

        double product = (firstValue + secondValue) * factor;

        return sum == product;
    }

    public bool DecimalSumAndMultiplication(decimal firstValue, decimal secondValue, int factor)
    {
        decimal sum = 0M;

        for (var i = 0; i < factor; i++)
        {
            sum += firstValue + secondValue;
        }

        decimal product = (firstValue + secondValue) * factor;

        return sum == product;
    }
}