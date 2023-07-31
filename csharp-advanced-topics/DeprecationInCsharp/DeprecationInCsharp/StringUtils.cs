public class StringUtils
{
    [Obsolete("This method is deprecated since version 2.0.0. Use ReverseStringV2 instead.",false)]
    public static string ReverseString(string originalString)
    {
        var charArray = originalString.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static string ReverseStringV2(string originalString)
    {
        var charArray = originalString.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}