namespace DeleteElementsFromAnArray 
{
    public static partial class Methods 
    {
        public static int[] DeleteWithWhere(int[] inputArray, int elementToDelete) 
        {
            return inputArray.Where(e => e != elementToDelete).ToArray();
        }
    }
}
