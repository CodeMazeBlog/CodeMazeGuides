namespace FindTheMaximumValue
{
    public class ElementFinder
    {
        public int GetLargestElementUsingMax(int[] sourceArray)
        {
            return sourceArray.Max();
        }

        public int GetLargestElementUsingOrderByDescending(int[] sourceArray)
        {
            return sourceArray.OrderByDescending(x => x).First();
        }

        public int GetLargestElementUsingMaxBy(int[] sourceArray)
        {
            return sourceArray.MaxBy(x => x);
        }

        public int GetLargestElementUsingFor(int[] sourceArray)
        {
            int maxElement = sourceArray[0];
            for (int index = 1; index < sourceArray.Length; index++)
            {
                if (sourceArray[index] > maxElement)
                    maxElement = sourceArray[index];
            }

            return maxElement;
        }
    }
}