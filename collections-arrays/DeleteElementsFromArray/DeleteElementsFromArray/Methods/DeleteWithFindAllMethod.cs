namespace DeleteElementsFromAnArray 
{
    public static partial class Methods 
    {
        public static int[] DeleteWithFindAll(int[] inputArray, int elementToDelete) 
        {
            return Array.FindAll(inputArray, i => i != elementToDelete);
        }
    }
}
