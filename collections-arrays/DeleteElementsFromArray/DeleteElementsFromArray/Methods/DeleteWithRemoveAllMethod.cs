namespace DeleteElementsFromAnArray 
{
    public static partial class Methods 
    {
        public static int[] DeleteWithRemoveAll(int[] inputArray, int elementToRemove) 
        {
            var list = new List<int>(inputArray);
            list.RemoveAll(e => e == elementToRemove);
            
            return list.ToArray();
        }
    }
}