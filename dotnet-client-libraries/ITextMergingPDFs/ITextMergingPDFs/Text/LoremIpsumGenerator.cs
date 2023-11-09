using System.Text;

namespace ITextMergingPDFs.Text
{
    public class LoremIpsumGenerator
    {
        private const string _loremIpsumText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        private static readonly string[] _loremIpsumWords = _loremIpsumText.Split(' ');

        protected LoremIpsumGenerator()
        {
            // to prevent creating instances of this class (it's static)
        }

        private static IEnumerable<string> GetWords(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return _loremIpsumWords[i % _loremIpsumWords.Length];
            }
        }

        public static string GenerateWords(int numberOfWords)
        {
            StringBuilder sb = new(numberOfWords * 10);
            sb.AppendJoin(' ', GetWords(numberOfWords));

            return sb.ToString();
        }

        public static string GenerateRandomNumberOfWords()
        {
            return GenerateWords(Random.Shared.Next(20, 200));
        }
    }
}
