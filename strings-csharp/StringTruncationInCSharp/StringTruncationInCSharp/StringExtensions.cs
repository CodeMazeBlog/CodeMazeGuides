namespace StringTruncationInCSharp
{
    public static class StringExtensions
    {
        public static string TruncateString(this string originalString, int maxLength)
        {
            var truncatedString = originalString.Substring(0, maxLength);

            return truncatedString;
        }
    }
}