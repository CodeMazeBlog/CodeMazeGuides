namespace EmptyStringArrayFactory;

public class ArrayFactory
{
    public static string[] CreateWithNewAndZeroLength()
    {
        return new string[0];
    }

    public static string[] CreateWithEmptyInitializer()
    {
        return new string[] { };
    }

    public static string[] CreateWithImplicitInitializer()
    {
        string[] myArray = { };

        return myArray;
    }

    public static string[] CreateWithEnumerableEmpty()
    {
        return Enumerable.Empty<string>().ToArray();
    }

    public static string[] CreateWithEnumerableRepeatEmptyString()
    {
        return Enumerable.Repeat("", 0).ToArray();
    }

    public static string[] CreateWithEnumerableRepeatStringEmpty()
    {
        return Enumerable.Repeat(string.Empty, 0).ToArray();
    }

    public static string[] CreateWithArrayEmpty()
    {
        return Array.Empty<string>();
    }

    public static string[] CreateEmptyArrayWithCollectionExpression() => [];
}
