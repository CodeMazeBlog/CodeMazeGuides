using System.Text;

namespace ITextMergingPDFs.Text
{
    public class LoremIpsumGenerator
    {
        private static readonly string loremIpsumText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        private static readonly string[] loremIpsumWords = loremIpsumText.Split(' ');
        private static readonly Random random = new();

        public static string GenerateWords(int numberOfWords)
        {
            StringBuilder sb = new(numberOfWords * 10);
            while (numberOfWords > 0)
            {
                int wordsToTake = Math.Min(numberOfWords, loremIpsumWords.Length);

                if (sb.Length > 0) sb.Append(' ');
                sb.AppendJoin(' ', loremIpsumWords.Take(wordsToTake));

                numberOfWords -= wordsToTake;
            }

            return sb.ToString();
        }

        public static string GenerateWords(int minNumberOfWords = 20, int maxNumberOfWords = 200)
        {
            return GenerateWords(random.Next(minNumberOfWords, maxNumberOfWords));
        }
    }
}
