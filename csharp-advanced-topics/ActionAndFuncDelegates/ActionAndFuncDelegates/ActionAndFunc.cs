namespace ActionAndFuncDelegates;

public class ActionAndFunc
{
    public static void GreetUser(string name) => Console.WriteLine($"Hello {name}, welcome to the magnificent world of Action Delegates.");
    public static string SquareToString(int x) => (x * x).ToString();
    public static IEnumerable<int> GetEvenSquaredNumbersAbove30()
    {
        List<int> numbers = Enumerable.Range(1, 10).ToList();

        Func<int, bool> isEven = x => x % 2 == 0;
        Func<int, int> square = x => x * x;
        Func<int, bool> isAbove30 = x => x > 30;

        var evenSquaredNumbersAbove30 = numbers
            .Where(isEven)
            .Select(square)
            .Where(isAbove30);

        return evenSquaredNumbersAbove30;
    }
}
