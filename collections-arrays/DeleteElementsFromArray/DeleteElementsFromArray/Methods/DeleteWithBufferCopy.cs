namespace DeleteElementsFromAnArray 
{
    public static partial class Methods 
    {
        public static int[] DeleteWithBufferCopy(int[] inputArray, int elementToRemove) 
        {
            var indexToRemove = Array.IndexOf(inputArray, elementToRemove);

            if(indexToRemove < 0) 
            {
                return inputArray;
            }

            var newArray = new int[inputArray.Length - 1];

            Buffer.BlockCopy(inputArray, 0, newArray, 0, indexToRemove *4);

            Buffer.BlockCopy(inputArray, (indexToRemove + 1) * 4, newArray, indexToRemove * 4, (inputArray.Length - indexToRemove - 1) * 4);

            return newArray;
        }
    }
}