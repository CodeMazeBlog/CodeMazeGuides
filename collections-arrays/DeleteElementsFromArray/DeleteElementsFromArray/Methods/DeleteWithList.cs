namespace DeleteElementsFromAnArray
{
    public static partial class Methods
    {
        public static int[] DeleteWithList(int[] inputArray, int elementToRemove)
        {
            var indexToRemove = Array.IndexOf(inputArray, elementToRemove);

            if (indexToRemove < 0)
            {
                return inputArray;
            }

            var list = new List<int>(inputArray.Length);

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] != elementToRemove)
                {
                    list.Add(inputArray[i]);
                }
            }

            return list.ToArray();
        }
    }
}
