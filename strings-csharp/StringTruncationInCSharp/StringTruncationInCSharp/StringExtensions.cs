namespace StringTruncationInCSharp
{
    public static class StringExtensions
    {
        public static string TruncateString(this string originalString, int maxLength)
        {
            if (maxLength <= 0)
            {
                return string.Empty;
            }
            else if (maxLength >= originalString.Length)
            {
                return originalString;
            }

            var truncatedString = originalString.Substring(0, maxLength);

            return truncatedString;
        }
    }
}