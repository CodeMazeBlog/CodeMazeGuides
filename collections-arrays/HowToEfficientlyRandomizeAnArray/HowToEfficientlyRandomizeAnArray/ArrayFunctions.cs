namespace HowToEfficientlyRandomizeAnArray
{
    public static class ArrayFunctions
    {
        public static int[] GetOrderedArray(int numberOfElements)
        {
            var array = new int[numberOfElements];

            for (int i = 0; i < numberOfElements; i++)
            {
                array[i] = i;
            }

            return array;
        }

        public static int[] RandomizeWithOrderByAndGuid(int[] array) =>
            array.OrderByDescending(x => Guid.NewGuid()).ToArray();

        public static int[] RandomizeWithOrderByAndRandom(int[] array) =>
            array.OrderByDescending(x => Random.Shared.Next()).ToArray();

        public static int[] RandomizeWithFisherYates(int[] array)
        {
            int count = array.Length;

            while (count > 1)
            {
                int i = Random.Shared.Next(count--);
                (array[i], array[count]) = (array[count], array[i]);
            }

            return array;
        }

        public static int[] RandomizeWithFisherYatesCopiedArray(int[] array)
        {
            int count = array.Length;
            var arrayCopy = new int[count];

            Array.Copy(array, arrayCopy, count);

            while (count > 1)
            {
                int i = Random.Shared.Next(count--);
                (arrayCopy[i], arrayCopy[count]) = (arrayCopy[count], arrayCopy[i]);
            }

            return arrayCopy;
        }
    }
}
