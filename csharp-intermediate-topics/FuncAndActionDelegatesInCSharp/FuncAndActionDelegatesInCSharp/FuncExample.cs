namespace FuncAndActionDelegatesInCSharp;

public static class FuncExample 
{
    public static int[] OrderNumberByAsc(int[] numbers)
    {
        // Order the numbers array in ascending order
        var orderedNumbers = numbers.OrderBy(n => n);

        // convert to array and return
        return orderedNumbers.ToArray();
    }
}