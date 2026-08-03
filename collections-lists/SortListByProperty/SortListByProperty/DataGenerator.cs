using System.Text;

namespace SortListByProperty
{
    public static class DataGenerator
    {
        private static readonly Random _random = new Random();

        public static int GenerateNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static string GenerateString(int size)
        {
            var builder = new StringBuilder(size);
            char start = 'a';

            for (int i = 0; i < size; i++)
            {
                var text = (char)_random.Next(start, start + 26);
                builder.Append(text);
            }

            return builder.ToString();
        }
    }
}
