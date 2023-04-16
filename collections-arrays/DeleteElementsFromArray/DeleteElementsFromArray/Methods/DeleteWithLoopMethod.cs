namespace DeleteElementsFromAnArray 
{
    public static partial class Methods 
    {
        public static int[] DeleteWithLoop(int[] inputArray, int elementToRemove) 
        {
            var indexToRemove = Array.IndexOf(inputArray, elementToRemove);

            if (indexToRemove < 0)
            {
                return inputArray;
            }

            var tempArray = new int[inputArray.Length - 1];

            for (int i = 0, j = 0; i < inputArray.Length; i++) 
            {
                if (i == indexToRemove) 
                {
                    continue;
                }
                tempArray[j] = inputArray[i];
                j++;
            }

            return tempArray;
        }
    }
}