namespace DefaultValuesForLambdaExpressions;

public static class Calculator
{
    public static int IncrementByValue(int value, int increase)
    {
        var Increment = (int value, int increase = 1) => value + increase;

        return Increment(value, increase);
    }

    public static int IncrementByDefaultValue(int value)
    {
        var Increment = (int value, int increase = 1) => value + increase;

        return Increment(value);
    }

    public static int Total(params int[] numbers)
    {
        var Total = (params int[] numbers) => numbers.Sum();

        return Total(numbers);
    }
}
