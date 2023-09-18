namespace ActionAndFunc;

public class ActionDelegate
{
    public static void DoubleNumber(int number)
    {
        Console.WriteLine($"Double of {number} is: {number * 2}");
    }

    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        Action<int> doubleAndPrint = DoubleNumber;

        numbers.ForEach(doubleAndPrint);
    }
}