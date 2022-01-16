namespace FuncUsageExample
{
    public static class CustomLinqExtensionMethod
    {
        public static IEnumerable<int> Filter(this IEnumerable<int> numberList, Func<int, bool> predicate)
        {
            foreach (var number in numberList)
            {
                if (predicate(number))
                {
                    yield return number;
                }
            }
        }
    }
}
