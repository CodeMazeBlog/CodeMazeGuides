namespace DeleteElementsFromAnArray;

public static partial class Methods
{
    public static int[] DeleteWithArraySegment(int[] inputArray, int elementToRemove)
    {
        var indexToRemove = Array.IndexOf(inputArray, elementToRemove);

        if (indexToRemove < 0)
        {
            return inputArray;
        }

        var segment1 = new ArraySegment<int>(inputArray, 0, indexToRemove);
        var segment2 = new ArraySegment<int>(inputArray, indexToRemove + 1, inputArray.Length - indexToRemove - 1);

        return segment1.Concat(segment2).ToArray();
    }
}
