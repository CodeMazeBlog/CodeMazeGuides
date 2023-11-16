using System.Text;
using System.Text.RegularExpressions;

namespace StringTruncationInCSharp
{
    public class StringHelper
    {
        public string TruncateStringUsingSubstring(string originalString, int maxLength)
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

        public string TruncateStringUsingRemove(string originalString, int maxLength)
        {
            if (maxLength <= 0)
            {
                return string.Empty;
            }
            else if (originalString.Length > maxLength)
            {
                return originalString.Remove(maxLength);
            }

            return originalString;
        }

        public string TruncateStringUsingForLoopWithStringBuilder(string originalString, int maxLength)
        {
            if (maxLength <= 0)
            {
                return string.Empty;
            }
            else if (maxLength >= originalString.Length)
            {
                return originalString;
            }

            var length = Math.Min(maxLength, originalString.Length);
            var truncatedStringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                truncatedStringBuilder.Append(originalString[i]);
            }

            var truncatedString = truncatedStringBuilder.ToString();

            return truncatedString;
        }

        public string TruncateStringUsingLINQ(string originalString, int maxLength)
        {
            var truncatedString = new string(originalString.Take(maxLength).ToArray());

            return truncatedString;
        }

        public string TruncateStringUsingForLoop(string originalString, int maxLength)
        {
            var truncatedString = string.Empty;
            int length = Math.Min(maxLength, originalString.Length);

            for (int i = 0; i < length; i++)
            {
                truncatedString += originalString[i];
            }

            return truncatedString;
        }

        public string TruncateStringUsingRegularExpressions(string originalString, int maxLength)
        {
            if (maxLength <= 0)
            {
                return string.Empty;
            }
            else if (maxLength >= originalString.Length)
            {
                return originalString;
            }

            var truncatedString = Regex.Replace(originalString, $"^(.{{0,{maxLength}}}).*$", "$1");

            return truncatedString;
        }

        public string TruncateStringUsingSpan(string originalString, int maxLength)
        {
            if (string.IsNullOrEmpty(originalString) || maxLength <= 0)
            {
                return string.Empty;
            }

            ReadOnlySpan<char> originalStringAsSpan = originalString.AsSpan();
            if (maxLength >= originalStringAsSpan.Length)
            {
                return originalString;
            }

            return originalStringAsSpan[..maxLength].ToString();
        }
    }
}