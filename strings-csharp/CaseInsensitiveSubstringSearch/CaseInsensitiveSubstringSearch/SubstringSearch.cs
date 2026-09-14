using System.Text.RegularExpressions;

namespace CaseInsensitiveSubstringSearch
{
    public class SubstringSearch
    {
        // String Contains Method Search
        public static bool StringContains(string sourceString, string substringToSearch)
        {
            return sourceString
                .Contains(substringToSearch, StringComparison.OrdinalIgnoreCase);
        }

        // String IndexOf Method Search
        public static bool StringIndexOf(string sourceString, string substringToSearch)
        {
            return sourceString
                .IndexOf(substringToSearch, StringComparison.OrdinalIgnoreCase) >= 0; // found
        }

        // String ToUpperInvariant Method Search
        public static bool StringToUpperInvariant(string sourceString, string substringToSearch)
        {
            return sourceString
                .ToUpperInvariant()
                .Contains(substringToSearch
                    .ToUpperInvariant());
        }

        // Regular Expression Search
        // Regex.Escape() treats the search term as literal text, so a term such as "c.de" or "z*"
        // is not reinterpreted as a pattern and an unmatched bracket does not throw.
        // RegexOptions.CultureInvariant keeps IgnoreCase off the current culture's casing rules.
        public static bool RegexIsMatch(string sourceString, string substringToSearch)
        {
            return Regex
                .IsMatch(sourceString,
                    Regex.Escape(substringToSearch),
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        }

        // Linq With String Equals Method Search
        // This matches whole separator-delimited words, not substrings, so it answers a different
        // question from the other four methods. That difference is intentional, not a bug.
        public static bool LinqStringEquals(string sourceString, string substringToSearch, char separator)
        {
            return sourceString
                .Split(separator)
                .Any(word => word
                    .Equals(substringToSearch, StringComparison.OrdinalIgnoreCase));
        }
    }
}
