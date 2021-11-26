namespace ActionAndFuncDelegates;

public static class NumberOperations
{
    /// <summary>
    /// Returns sum of numbers if each of them respects the validation rules, otherwise throws an exception.
    /// </summary>
    public static int SumNumbers(int[] numbers, Func<int, bool> checkValidation, Action<int> throwException)
    {
        var sum = 0;
        foreach (var number in numbers)
        {
            if (checkValidation(number))
            {
                sum += number;
            }
            else
            {
                throwException(number);
            }
        }
        return sum;
    }

    /// <summary>
    /// Checks if a number is odd
    /// </summary>
    public static bool IsOdd(int number)
    {
        return number % 2 != 0;
    }

    /// <summary>
    /// Throws exception with odd logic related message
    /// </summary>
    public static void ThrowNumberShouldBeOddException(int number)
    {
        throw new Exception($"Provided number {number} is not odd");
    }


}

