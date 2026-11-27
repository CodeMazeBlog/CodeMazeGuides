using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace StringTruncationInCSharp;

public static class StringHelper
{
    public static string TruncateWithSubstring(string originalString, int maxLength)
    {
        return TruncateString(originalString, maxLength, UsingSubstring);

        static string UsingSubstring(string str, int length) => str[..length];
    }

    public static string TruncateWithRemove(string originalString, int maxLength)
    {
        return TruncateString(originalString, maxLength, UsingRemove);

        static string UsingRemove(string str, int length) => str.Remove(length);
    }

    public static string TruncateWithForLoopStringBuilder(string originalString, int maxLength)
    {
        return TruncateString(originalString, maxLength, UsingForLoopStringBuilder);

        static string UsingForLoopStringBuilder(string str, int length)
        {
            var truncatedStringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                truncatedStringBuilder.Append(str[i]);
            }

            return truncatedStringBuilder.ToString();
        }
    }

    public static string TruncateWithLINQ(string originalString, int maxLength)
    {
        return TruncateString(originalString, maxLength, UsingLINQ);

        static string UsingLINQ(string str, int length) => new(str.Take(length).ToArray());
    }

    public static string TruncateWithRegularExpressions(string originalString, int maxLength)
    {
        return TruncateString(originalString, maxLength, UsingRegularExpressions);

        static string UsingRegularExpressions(string str, int length) =>
            Regex.Replace(str, $"^(.{{0,{length}}}).*$", "$1", RegexOptions.Singleline);
    }

    public static string TruncateWithSpan(string originalString, int maxLength)
    {
        return TruncateString(originalString, maxLength, UsingSpan);

        static string UsingSpan(string str, int length) => str.AsSpan()[..length].ToString();
    }

    public static string TruncateWithSurrogateCheck(string originalString, int maxLength)
    {
        return TruncateString(originalString, maxLength, UsingSurrogateCheck);

        static string UsingSurrogateCheck(string str, int length) =>
            char.IsHighSurrogate(str[length - 1]) ? str[..(length - 1)] : str[..length];
    }

    public static string TruncateWithTextElements(string originalString, int maxLength)
    {
        return TruncateString(originalString, maxLength, UsingTextElements);

        static string UsingTextElements(string str, int length)
        {
            var end = 0;

            while (end < length)
            {
                var next = StringInfo.GetNextTextElementLength(str, end);

                if (end + next > length)
                {
                    break;
                }

                end += next;
            }

            return str[..end];
        }
    }

    private static string TruncateString(string originalString, int maxLength,
        Func<string, int, string> specificTruncateMethod)
    {
        if (maxLength <= 0)
        {
            return string.Empty;
        }

        if (maxLength >= originalString.Length)
        {
            return originalString;
        }

        return specificTruncateMethod(originalString, maxLength);
    }
}