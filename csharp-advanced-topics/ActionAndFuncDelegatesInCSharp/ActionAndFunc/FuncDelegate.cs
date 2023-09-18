namespace ActionAndFunc;

public class FuncDelegate
{
    // Function to check if a number is even
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Using Func delegate to check if a number is even
        Func<int, bool> isEvenDelegate = IsEven;
        
        foreach (var number in numbers)
        {
            bool result = isEvenDelegate(number);
            Console.WriteLine($"{number} is even: {result}");
        }
    }
}