namespace DeleteElementsFromAnArray;

public static partial class Methods
{
    public static int[] DeleteWithBufferCopy(int[] inputArray, int elementToRemove)
    {
        var indexToRemove = Array.IndexOf(inputArray, elementToRemove);

        if (indexToRemove < 0)
        {
            return inputArray;
        }

        var tempArray = new int[inputArray.Length - 1];

        Buffer.BlockCopy(inputArray, 0, tempArray, 0, indexToRemove * sizeof(int));

        Buffer.BlockCopy(inputArray,
            (indexToRemove + 1) * sizeof(int),
            tempArray,
            indexToRemove * sizeof(int),
            (inputArray.Length - indexToRemove - 1) * sizeof(int));

        return tempArray;
    }
}
