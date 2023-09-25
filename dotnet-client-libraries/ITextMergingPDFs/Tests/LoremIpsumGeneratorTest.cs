using ITextMergingPDFs.Text;

namespace Tests
{
    [TestClass]
    public class LoremIpsumGeneratorTest
    {
        [TestMethod]
        public void GivenLoremIpsumGenerator_WhenUsingGenerateWords_ThenCorrectNumberOfWords()
        {
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                var numberOfWords = rnd.Next(5, 100);
                var result = LoremIpsumGenerator.GenerateWords(numberOfWords);
                var numberOfWordsInResult = result.Split(' ').Length;

                Assert.AreEqual(numberOfWords, numberOfWordsInResult);
            }
        }
    }
}
