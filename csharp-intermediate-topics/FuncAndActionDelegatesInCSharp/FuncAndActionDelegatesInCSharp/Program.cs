namespace FuncAndActionDelegatesInCSharp;

class Program
{
    public static void Main()
    {
        // Func Example 
        int[] numbers = { 3, 6, 1, 8, 2, 9, 4, 7, 5 };
        var numberOrderdByAsc = FuncExample.OrderNumberByAsc(numbers);
        foreach(var num in numberOrderdByAsc)
        {
            Console.Write(num+" ");
        }
        
        Console.WriteLine();
        Console.WriteLine("=========================");

        // Action Example
        var words = new List<string> { "apple", "banana", "cherry" , "kiwi" , "strawberry", "mango" };
        Action<string> print = Console.WriteLine;
        ActionExample.ProcessStringsUsingAction(words, print);
    }
}