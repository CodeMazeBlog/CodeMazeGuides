namespace AnyAndExistsMethodsInCSharp;

public static class NumbersHelper
{
    public static bool CheckIfArrayIsEmpty(int[] numbers)
        => !numbers.Any();

    public static bool CheckIfListContainsPositiveNumbersAny(List<int> numbers)
        => numbers.Any(x => x > 0);

    public static bool CheckIfListContainsPositiveNumbersExists(List<int> numbers)
        => numbers.Exists(x => x > 0);

    public static bool CheckIfArrayContainsPositiveNumbersExists(int[] numbers)
        => Array.Exists(numbers, x => x > 0);
}
