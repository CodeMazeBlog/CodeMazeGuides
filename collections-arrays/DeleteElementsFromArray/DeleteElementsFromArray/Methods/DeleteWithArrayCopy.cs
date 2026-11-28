namespace DeleteElementsFromAnArray;

public static partial class Methods
{
    public static int[] DeleteWithArrayCopy(int[] inputArray, int elementToRemove)
    {
        var indexToRemove = Array.IndexOf(inputArray, elementToRemove);

        if (indexToRemove < 0)
        {
            return inputArray;
        }

        var tempArray = new int[inputArray.Length - 1];

        Array.Copy(inputArray, 0, tempArray, 0, indexToRemove);
        Array.Copy(inputArray, indexToRemove + 1, tempArray, indexToRemove, inputArray.Length - indexToRemove - 1);

        return tempArray;
    }
}
