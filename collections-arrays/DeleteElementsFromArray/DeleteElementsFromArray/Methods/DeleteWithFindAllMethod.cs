namespace DeleteElementsFromAnArray 
{
    public static partial class Methods 
    {
        public static int[] DeleteWithFindAll(int[] inputArray, int elementToRemove) 
        {
            return Array.FindAll(inputArray, i => i != elementToRemove);
        }
    }
}