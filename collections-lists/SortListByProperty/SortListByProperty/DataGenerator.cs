using System.Text;

namespace SortListByProperty;

public static class DataGenerator
{
    public static int GenerateNumber(int min, int max)
    {
        return Random.Shared.Next(min, max);
    }

    public static string GenerateString(int size)
    {
        var builder = new StringBuilder(size);
        char start = 'a';

        for (int i = 0; i < size; i++)
        {
            var text = (char)Random.Shared.Next(start, start + 26);
            builder.Append(text);
        }

        return builder.ToString();
    }
}
