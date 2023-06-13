namespace HowToEfficientlyRandomizeAnArray
{
    public class ArrayFunctions
    {
        private readonly Random _rnd;

        public ArrayFunctions()
        {
            _rnd = new Random();
        }

        public int[] GerOrderedArray(int numberOfElements)
        {
            int[] array = new int[numberOfElements];

            for (int i = 0; i < numberOfElements; i++)
            {
                array[i] = i;
            }

            return array;
        }

        public int[] RandomizeWithOrderByAndGuid(int[] array) =>
            array.OrderByDescending(x => Guid.NewGuid()).ToArray();

        public int[] RandomizeWithOrderByAndRandom(int[] array) => array.OrderByDescending(x => _rnd.Next()).ToArray();

        public int[] RandomizeWithFisherYates(int[] array)
        {
            int count = array.Length;

            while (count > 1)
            {
                int i = _rnd.Next(count--);
                (array[i], array[count]) = (array[count], array[i]);
            }

            return array;
        }
    }
}
