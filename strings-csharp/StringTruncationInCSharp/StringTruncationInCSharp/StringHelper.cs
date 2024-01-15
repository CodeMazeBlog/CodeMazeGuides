using System.Text;
using System.Text.RegularExpressions;

namespace StringTruncationInCSharp
{
    public static class StringHelper
    {
        public static string TruncateWithSubstring(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingSubstring);

            static string UsingSubstring(string str, int length)
            {
                return str.Substring(0, length);
            }
        }

        public static string TruncateWithRemove(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingRemove);

            static string UsingRemove(string str, int length)
            {
                return str.Remove(length);
            }
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

            static string UsingLINQ(string str, int length)
            {
                var truncatedString = new string(str.Take(length).ToArray());

                return truncatedString;
            }
        }

        public static string TruncateWithForLoop(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingForLoop);

            static string UsingForLoop(string str, int length)
            {
                var truncatedString = string.Empty;
                var loopLength = Math.Min(length, str.Length);

                for (int i = 0; i < loopLength; i++)
                {
                    truncatedString += str[i];
                }

                return truncatedString;
            }
        }

        public static string TruncateWithRegularExpressions(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingRegularExpressions);

            static string UsingRegularExpressions(string str, int length)
            {
                return Regex.Replace(str, $"^(.{{0,{length}}}).*$", "$1");
            }
        }

        public static string TruncateWithSpan(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingSpan);

            static string UsingSpan(string str, int length)
            {
                var originalStringAsSpan = str.AsSpan();
                return originalStringAsSpan[..length].ToString();
            }
        }

        private static string TruncateString(string originalString, int maxLength, Func<string, int, string> specificTruncateMethod)
        {
            if (maxLength <= 0)
            {
                return string.Empty;
            }
            else if (maxLength >= originalString.Length)
            {
                return originalString;
            }

            return specificTruncateMethod(originalString, maxLength);
        }
    }
}