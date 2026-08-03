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
        public static bool RegexIsMatch(string sourceString, string substringToSearch)
        {
            return Regex
                .IsMatch(sourceString, substringToSearch, RegexOptions.IgnoreCase);
        }

        // Linq With String Equals Method Search
        public static bool LinqStringEquals(string sourceString, string substringToSearch, char separator)
        {
            return sourceString
                .Split(separator)
                .Any(word => word
                    .Equals(substringToSearch, StringComparison.OrdinalIgnoreCase));
        }
    }
}
