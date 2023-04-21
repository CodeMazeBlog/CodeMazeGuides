namespace DeleteElementsFromAnArray 
{
    public static partial class Methods 
    {
        public static int[] DeleteWithWhere(int[] inputArray, int elementToRemove) 
        {
            return inputArray.Where(e => e != elementToRemove).ToArray();
        }
    }
}