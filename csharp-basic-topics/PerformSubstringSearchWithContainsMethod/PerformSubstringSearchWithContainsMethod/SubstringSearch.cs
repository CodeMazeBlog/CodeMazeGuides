using System.Text.RegularExpressions;

namespace PerformSubstringSearchWithContainsMethod
{
    public class SubstringSearch
    {
        public static void Main(string[] args)
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var separator = ' ';

            // String Contains Method Search
            StringContainsSubstringWithNoParameter(sourceString, substringToSearch);
            StringContainsSubstringWithOrdinalStringComparisonParameter(sourceString, substringToSearch);
            StringContainsSubstringWithOrdinalIgnoreCaseStringComparisonParameter(sourceString, substringToSearch);

            // String IndexOf Method Search
            StringIndexOfMethodSearchWithNoParameter(sourceString, substringToSearch);
            StringIndexOfMethodSearchWithOrdinalStringComparisonParameter(sourceString, substringToSearch);
            StringIndexOfMethodSearchWithOrdinalIgnoreCaseStringComparisonParameter(sourceString, substringToSearch);

            // Regular Expression Search
            RegularExpressionSearchWithNoParameter(sourceString, substringToSearch);
            RegularExpressionSearchWithRegexOptionsNoneParameter(sourceString, substringToSearch);
            RegularExpressionSearchWithRegexOptionsIgnoreCaseParameter(sourceString, substringToSearch);

            // Linq With String Equals Method Search
            LinqWithStringEqualsMethodSearchWithNoParameter(sourceString, substringToSearch, separator);
            LinqWithStringEqualsMethodSearchWithOrdinalStringComparisonParameter(sourceString, substringToSearch, separator);
            LinqWithStringEqualsMethodSearchWithOrdinalIgnoreCaseStringComparisonParameter(sourceString, substringToSearch, separator);
        }

        // String Contains Method Search
        public static bool StringContainsSubstringWithNoParameter(string sourceString, string substringToSearch)
        {
            return sourceString.Contains(substringToSearch); // false
        }

        public static bool StringContainsSubstringWithOrdinalStringComparisonParameter(string sourceString, string substringToSearch)
        {
            return sourceString.Contains(substringToSearch, StringComparison.Ordinal); // false
        }

        public static bool StringContainsSubstringWithOrdinalIgnoreCaseStringComparisonParameter(string sourceString, string substringToSearch)
        {
            return sourceString.Contains(substringToSearch, StringComparison.OrdinalIgnoreCase); // true
        }

        // String IndexOf Method Search
        public static int StringIndexOfMethodSearchWithNoParameter(string sourceString, string substringToSearch)
        {
            return sourceString.IndexOf(substringToSearch); // -1 (not found)
        }

        public static int StringIndexOfMethodSearchWithOrdinalStringComparisonParameter(string sourceString,
            string substringToSearch)
        {
            return sourceString.IndexOf(substringToSearch, StringComparison.Ordinal); // -1 (not found)
        }

        public static int StringIndexOfMethodSearchWithOrdinalIgnoreCaseStringComparisonParameter(string sourceString,
            string substringToSearch)
        {
            return sourceString.IndexOf(substringToSearch, StringComparison.OrdinalIgnoreCase); // 5 (found)
        }

        // Regular Expression Search
        public static bool RegularExpressionSearchWithNoParameter(string sourceString, string substringToSearch)
        {
            return Regex.IsMatch(sourceString, substringToSearch); // false
        }

        public static bool RegularExpressionSearchWithRegexOptionsNoneParameter(string sourceString,
            string substringToSearch)
        {
            return Regex.IsMatch(sourceString, substringToSearch, RegexOptions.None); // false
        }

        public static bool RegularExpressionSearchWithRegexOptionsIgnoreCaseParameter(string sourceString,
            string substringToSearch)
        {
            return Regex.IsMatch(sourceString, substringToSearch, RegexOptions.IgnoreCase); // true
        }

        // Linq With String Equals Method Search
        public static bool LinqWithStringEqualsMethodSearchWithNoParameter(string sourceString,
            string substringToSearch, char separator)
        {
            return sourceString
                .Split(separator)
                .Any(word => word.Equals(substringToSearch)); // false
        }

        public static bool LinqWithStringEqualsMethodSearchWithOrdinalStringComparisonParameter(string sourceString,
            string substringToSearch, char separator)
        {
            return sourceString
                .Split(separator)
                .Any(word => word.Equals(substringToSearch, StringComparison.Ordinal)); // false
        }

        public static bool LinqWithStringEqualsMethodSearchWithOrdinalIgnoreCaseStringComparisonParameter(
            string sourceString, string substringToSearch, char separator)
        {
            return sourceString
                .Split(separator)
                .Any(word => word.Equals(substringToSearch, StringComparison.OrdinalIgnoreCase)); // true
        }
    }
}