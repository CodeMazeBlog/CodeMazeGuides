namespace RangesAndIndicesExample;

public class IndexExamples
{
    public static string GetFirst(string[] names)
    {
        var index = new Index(0);

        return names[index];
    }

    public static string GetLastMethod1(string[] names)
    {
        var index = new Index(1, true);

        return names[index];
    }

    public static string GetLastMethod2(string[] names)
    {
        return names[^1];
    }

    public static string GetSecondLast(string[] names)
    {
        return names[^2];
    }
}