using System.Text;
using System.Text.RegularExpressions;

namespace StringTruncationInCSharp
{
    public class StringHelper
    {
        public string TruncateWithSubstring(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingSubstring);

            string UsingSubstring(string str, int length)
            {
                return str.Substring(0, length);
            }
        }

        public string TruncateWithRemove(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingRemove);

            string UsingRemove(string str, int length)
            {
                return str.Remove(length);
            }
        }

        public string TruncateWithForLoopStringBuilder(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingForLoopStringBuilder);

            string UsingForLoopStringBuilder(string str, int length)
            {
                var len = Math.Min(length, str.Length);
                var truncatedStringBuilder = new StringBuilder(len);

                for (int i = 0; i < len; i++)
                {
                    truncatedStringBuilder.Append(str[i]);
                }

                return truncatedStringBuilder.ToString();
            }
        }

        public string TruncateWithLINQ(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingLINQ);

            string UsingLINQ(string str, int length)
            {
                var truncatedString = new string(str.Take(length).ToArray());

                return truncatedString;
            }
        }

        public string TruncateWithForLoop(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingForLoop);

            string UsingForLoop(string str, int length)
            {
                var truncatedString = string.Empty;
                int loopLength = Math.Min(length, str.Length);

                for (int i = 0; i < loopLength; i++)
                {
                    truncatedString += str[i];
                }

                return truncatedString;
            }
        }

        public string TruncateWithRegularExpressions(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingRegularExpressions);

            string UsingRegularExpressions(string str, int length)
            {
                return Regex.Replace(str, $"^(.{{0,{length}}}).*$", "$1");
            }
        }

        public string TruncateWithSpan(string originalString, int maxLength)
        {
            return TruncateString(originalString, maxLength, UsingSpan);

            string UsingSpan(string str, int length)
            {
                ReadOnlySpan<char> originalStringAsSpan = str.AsSpan();
                return originalStringAsSpan[..length].ToString();
            }
        }

        private string TruncateString(string originalString, int maxLength, Func<string, int, string> specificTruncateMethod)
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