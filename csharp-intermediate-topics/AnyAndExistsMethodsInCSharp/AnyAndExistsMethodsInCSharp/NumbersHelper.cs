namespace AnyAndExistsMethodsInCSharp
{
    public static class NumbersHelper
    {
        public static bool CheckIfArrayIsEmpty(int[] numbers) => !numbers.Any();

        public static bool CheckIfListContainsPositiveNumbers_Any(List<int> numbers) => numbers.Any(x => x > 0);

        public static bool CheckIfListContainsPositiveNumbers_Exists(List<int> numbers) => numbers.Exists(x => x > 0);
    }
}
