namespace DeleteElementsFromAnArray;

public static partial class Methods
{
    public static int[] DeleteWithCollectionExpression(int[] inputArray, int elementToRemove)
    {
        var indexToRemove = Array.IndexOf(inputArray, elementToRemove);

        if (indexToRemove < 0)
        {
            return inputArray;
        }

        var span = inputArray.AsSpan();

        return [.. span[..indexToRemove], .. span[(indexToRemove + 1)..]];
    }

    public static int[] DeleteFirstElement(int[] inputArray)
    {
        return inputArray[1..];
    }
}
