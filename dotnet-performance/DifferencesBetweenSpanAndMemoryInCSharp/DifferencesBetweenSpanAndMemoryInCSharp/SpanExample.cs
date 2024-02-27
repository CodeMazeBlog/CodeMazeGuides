namespace DifferencesBetweenSpanAndMemoryInCSharp;

public static class SpanExample
{
    public static void IntArrayAsSpan()
    {
        int[] array = [1, 2, 3, 4, 5];

        var firstThreeElements = new Span<int>(array, 0, 3);
        var lastThreeElements = new Span<int>(array, array.Length - 3, 3);

        firstThreeElements[0] = 0;
        firstThreeElements[2] = 8;
        lastThreeElements[0] = 10;
        lastThreeElements[1] = 11;

        foreach (var element in array)
        {
            Console.WriteLine(element);
        }
    }

    public static void SubstringWithSpan(string input, int start, int length)
    {
        var subString = input.AsSpan().Slice(start, length);
        Console.WriteLine(subString.ToString());
    }
}
