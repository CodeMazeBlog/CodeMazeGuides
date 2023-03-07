using System.Text;
using System.Text.RegularExpressions;

namespace RemoveWhitespaceCharactersFromString
{
    public class RemoveWhitespaceMethods
    {
        public static string RemoveWhitespacesUsingRegex(string source)
        {
            return Regex.Replace(source, @"\s+", String.Empty);
        }

        public static string RemoveWhitespacesUsingLinq(string source)
        {
            return string.Concat(source.Where(c => !char.IsWhiteSpace(c)));
        }

        public static string RemoveWhitespacesUsingReplace(string source)
        {
            return source.Replace(" ", string.Empty);
        }

        public static string RemoveWhitespacesUsingTrim(string source)
        {
            return source.Trim();
        }

        public static string RemoveWhitespacesUsingStringBuilder(string source)
        {
            var builder = new StringBuilder(source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                char c = source[i];
                if (!char.IsWhiteSpace(c))
                    builder.Append(c);
            }
            return builder.ToString();
        }
    }
}
