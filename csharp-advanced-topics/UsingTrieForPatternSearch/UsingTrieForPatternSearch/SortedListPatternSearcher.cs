namespace UsingTrieForPatternSearch
{
    public class SortedListPatternSearcher
    {
        public static bool Search(string text, string pattern)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern) || text.Length < pattern.Length)
            {
                return false;
            }

            var substrings = new SortedList<string, bool>();
            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                substrings[text.Substring(i, pattern.Length)] = true;
            }

            return substrings.ContainsKey(pattern);
        }
    }
}
