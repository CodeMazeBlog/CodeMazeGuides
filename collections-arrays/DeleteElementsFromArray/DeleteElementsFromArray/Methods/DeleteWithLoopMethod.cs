namespace DeleteElementsFromAnArray 
{
    public static partial class Methods 
    {
        public static int[] DeleteWithLoop(int[] inputArray, int elementToDelete) 
        {
            var indexToRemove = Array.IndexOf(inputArray, elementToDelete);

            if (indexToRemove >= 0) 
            {
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

            return inputArray;
        }
    }
}
