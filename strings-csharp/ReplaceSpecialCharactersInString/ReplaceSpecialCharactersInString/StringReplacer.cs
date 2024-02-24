using System.Text;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace ReplaceSpecialCharactersInString
{
    [MemoryDiagnoser]
    public class StringReplacer
    {
        [Benchmark]
        public static string ReplaceUsingStringReplace(string originalString , char charToBeReplaced, char charToReplace)
        {
            return originalString.Replace(charToBeReplaced.ToString(), charToReplace.ToString());
        }


        [Benchmark]
        public static string ReplaceUsingStringBuilder(string originalString , char charToBeReplaced, char charToReplace)
        {
            var sb = new StringBuilder(originalString);

            sb.Replace(charToBeReplaced.ToString(), charToReplace.ToString());

            return sb.ToString();
        }


        [Benchmark]
        public static string ReplaceUsingRegex(string originalString, char charToBeReplaced, char charToReplace)
        {
            var pattern = $"[{Regex.Escape(charToBeReplaced.ToString())}]";

            return Regex.Replace(originalString, pattern, charToReplace.ToString());
        }


        [Benchmark]
        public static string ReplaceUsingSpan(string originalString , char charToBeReplaced, char charToReplace)
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


        [Benchmark]
        public static string ReplaceUsingInefficientMultipleReplacementsStringReplace(string originalString , char charToBeReplaced, char charToReplace)
        {
            var replacedString = originalString
                .Replace(charToReplace.ToString(), charToBeReplaced.ToString())
                .Replace("c", "")
                .Replace(charToBeReplaced.ToString(), charToReplace.ToString());

            return replacedString;
        }


        [Benchmark]
        public static string ReplaceUsingMemoryImpactStringReplace(string originalString , char charToBeReplaced, char charToReplace)
        {
            var replacedString = originalString.Replace(charToBeReplaced.ToString(), charToReplace.ToString());

            return replacedString;
        }


        [Benchmark]
        public static string ReplaceUsingCompiledRegex(string originalString , char charToBeReplaced, char charToReplace)
        {
            var compiledRegex = new Regex($"[{Regex.Escape(charToBeReplaced.ToString())}{Regex.Escape(charToReplace.ToString())}]", RegexOptions.Compiled);
            var replacedString = compiledRegex.Replace(originalString, "");

            return replacedString;
        }


        [Benchmark]
        public static string ReplaceUsingDotNet8Features(string originalString , char charToBeReplaced, char charToReplace)
        {
            var replacedString = Regex.Replace(originalString, $"[{Regex.Escape(charToBeReplaced.ToString())}{Regex.Escape(charToReplace.ToString())}]", "", RegexOptions.NonBacktracking);

            return replacedString;
        }


        [Benchmark]
        public static string ReplaceUsingUnsafeCode(string originalString , char charToBeReplaced, char charToReplace)
        {
            unsafe
            {
                fixed (char* ptr = originalString)
                {
                    for (int i = 0; i < originalString.Length; i++)
                    {
                        if (ptr[i] == charToBeReplaced)
                            ptr[i] = charToReplace;
                    }
                }
            }

            return originalString;
        }
    }
}
