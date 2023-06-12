namespace HowToEfficientlyRandomizeAnArray
{
    public static class ArrayFunctions
    {
        public static int[] GerOrderedArray(int numberOfElements)
        {
            int[] array = new int[numberOfElements];

            for (int i = 0; i < numberOfElements; i++)
            {
                array[i] = i;
            }

            return array;
        }

        public static int[] RandomizeWithOrderByAndGuid(int[] array) =>
            array.OrderBy(x => Guid.NewGuid()).ToArray();

        public static int[] RandomizeWithOrderByAndRandom(int[] array)
        {
            var rnd = new Random();

            return array.OrderBy(x => rnd.Next()).ToArray();
        }

        public static int[] RandomizeWithFisherYates(int[] array)
        {
            var rnd = new Random();
            int count = array.Length;

            while (count > 1)
            {
                int i = rnd.Next(count--);
                var temp = array[count];
                array[count] = array[i];
                array[i] = temp;
            }

            return array;
        }
    }
}
