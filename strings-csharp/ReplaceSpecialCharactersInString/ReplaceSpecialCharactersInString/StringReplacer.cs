using System.Text;
using System.Text.RegularExpressions;

namespace ReplaceSpecialCharactersInString
{
    public class StringReplacer
    {
        public static string ReplaceUsingStringReplace(string originalString,
            char oldChar, char newChar)
        {
            return originalString.Replace(oldChar, newChar);
        }


        public static string ReplaceUsingStringBuilder(string originalString,
            char oldChar, char newChar)
        {
            var sb = new StringBuilder(originalString);

            sb.Replace(oldChar, newChar);

            return sb.ToString();
        }


        public static string ReplaceUsingRegex(string originalString,
            string oldChar, string newChar)
        {
            var pattern = $"[{Regex.Escape(oldChar)}]";

            return Regex.Replace(originalString, pattern, newChar);
        }


        public static string ReplaceUsingSpan(string originalString,
            char charToBeReplaced, char charToReplace)
        {
            var originalChars = originalString.ToCharArray();

            var span = new Span<char>(originalChars);

            for (int i = 0; i < originalString.Length; i++)
            {
                if (span[i] == charToBeReplaced)
                    span[i] = charToReplace;
            }

            return new string(span.ToArray());
        }


        public static string ReplaceUsingInefficientMultipleReplacementsStringReplace(
            string originalString, char oldChar, char newChar)
        {
            var replacedString = originalString
                .Replace(newChar, oldChar)
                .Replace("c", "")
                .Replace(oldChar, newChar);

            return replacedString;
        }


        public static string ReplaceUsingMemoryImpactStringReplace(
               string originalString, char oldChar, char newChar)
        {
            var iterations = 10;
            var replacedString = originalString;

            for (int i = 0; i < iterations; i++)
            {
                replacedString = replacedString.Replace(oldChar, newChar);
            }

            return replacedString;
        }


        public static string ReplaceUsingCompiledRegex(string originalString,
               string oldChar, string newChar)
        {
            var pattern = $"[{Regex.Escape(oldChar)}{Regex.Escape(newChar)}]";

            var compiledRegex = new Regex(pattern, RegexOptions.Compiled);

            var replacedString = compiledRegex.Replace(originalString, " ");

            return replacedString;
        }


        public static string ReplaceUsingNonBacktrackingRegex(string originalString,
               string oldChar, string newChar)
        {
            var pattern = $"[{Regex.Escape(oldChar)}{Regex.Escape(newChar)}]";

            var replacedString = Regex.Replace(originalString, pattern, " ",
                RegexOptions.NonBacktracking);

            return replacedString;
        }



        public static string ReplaceUsingUnsafeCode(string originalString,
            char oldChar, char newChar)
        {
            unsafe
            {
                fixed (char* ptr = originalString)
                {
                    for (int i = 0; i < originalString.Length; i++)
                    {
                        if (ptr[i] == oldChar)
                            ptr[i] = newChar;
                    }
                }
            }

            return originalString;
        }
    }
}
