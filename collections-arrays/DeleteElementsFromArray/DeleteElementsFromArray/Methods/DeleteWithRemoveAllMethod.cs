namespace DeleteElementsFromAnArray 
{
    public static partial class Methods 
    {
        public static int[] DeleteWithRemoveAll(int[] inputArray, int elementToDelete) 
        {
            var list = new List<int>(inputArray);
            list.RemoveAll(e => e == elementToDelete);

            return list.ToArray();
        }
    }
}
