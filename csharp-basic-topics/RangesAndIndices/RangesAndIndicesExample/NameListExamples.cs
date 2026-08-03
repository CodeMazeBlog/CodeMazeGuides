namespace RangesAndIndicesExample;

public class NameListExamples
{
    public static List<string> GetAll(NameList names)
    {
        return names[..];
    }

    public static List<string> GetFirstTwoElements(NameList names)
    {
        var start = new Index(0);
        var end = new Index(2);
        var range = new Range(start, end);

        return names[range];
    }

    public static List<string> GetFirstThreeElements(NameList names)
    {
        return names[..3];
    }

    public static List<string> GetLastThreeElements(NameList names)
    {
        return names[^3..];
    }

    public static List<string> GetThreeElementsFromMiddle(NameList names)
    {
        return names[3..6];
    }

    public static string GetLastElement(NameList names)
    {
        return names[^1];
    }
}