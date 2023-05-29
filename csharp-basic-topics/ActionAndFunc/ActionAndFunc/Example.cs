namespace ActionAndFunc
{
    public static class Example
    {
        public static void PrintNumbersWithoutAction(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        public static void PrintNumbersWithAction(List<int> numbers, Action<int> action)
        {
            numbers.ForEach(action);
        }
    }
}
