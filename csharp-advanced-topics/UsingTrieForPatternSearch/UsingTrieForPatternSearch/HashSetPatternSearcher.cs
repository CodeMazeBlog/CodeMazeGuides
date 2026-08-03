namespace UsingTrieForPatternSearch
{
    public class HashSetPatternSearcher
    {
        public static bool Search(string text, string pattern)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern))
            {
                return false;
            }

            var patternSet = new HashSet<string> { pattern };
            var patternLength = pattern.Length;

            for (int i = 0; i <= text.Length - patternLength; i++)
            {
                var subString = text.Substring(i, patternLength);

                if (patternSet.Contains(subString))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
