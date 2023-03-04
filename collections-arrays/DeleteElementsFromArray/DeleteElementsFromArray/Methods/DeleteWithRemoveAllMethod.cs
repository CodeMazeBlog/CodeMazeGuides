namespace DeleteElementsFromAnArray 
{
    public static partial class Methods 
    {
        public static int[] DeleteRemoveAll(int[] inputArray, int elementToDelete) 
        {
            var list = new List<int>(inputArray);
            list.RemoveAll(e => e == elementToDelete);

            return list.ToArray();
        }
    }
}
