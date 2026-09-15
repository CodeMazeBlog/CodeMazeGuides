namespace CountingCharOccurences
{
    public class CountSubstringsAndFrequencies
    {
        public int CountSubstringNonOverlapping(string source, string toFind)
        {
            return source.AsSpan().Count(toFind);
        }

        public int CountSubstringOverlapping(string source, string toFind)
        {
            var count = 0;

            for (var n = 0; (n = source.IndexOf(toFind, n, StringComparison.Ordinal)) != -1; n++)
                count++;

            return count;
        }

        public Dictionary<char, int> CountEveryCharUsingLinq(string source)
        {
            return source.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<char, int> CountEveryCharUsingLoop(string source)
        {
            var counted = new Dictionary<char, int>();

            foreach (var c in source)
                counted[c] = counted.GetValueOrDefault(c) + 1;

            return counted;
        }
    }
}
