namespace UsingTrieForPatternSearch
{
    public class ListPatternSearcher
    {
        public static bool Search(string text, string pattern)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern) || text.Length < pattern.Length)
            { 
                return false; 
            }

            var substrings = new List<string>();
            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                substrings.Add(text.Substring(i, pattern.Length));
            }

            return substrings.Contains(pattern);
            
        }
    }
}
