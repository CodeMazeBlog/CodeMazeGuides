using ITextMergingPDFs.Text;

namespace Tests
{
    [TestClass]
    public class LoremIpsumGeneratorTest
    {
        [TestMethod]
        public void GivenLoremIpsumGenerator_WhenUsingGenerateWords_ThenCorrectNumberOfWordsIsExpected()
        {
            var rnd = new Random();

            for (var i = 0; i < 10; i++)
            {
                var numberOfWords = rnd.Next(5, 500);
                var result = LoremIpsumGenerator.GenerateWords(numberOfWords);
                var numberOfWordsInResult = result.Split(' ').Length;

                Assert.AreEqual(numberOfWords, numberOfWordsInResult);
            }
        }

        [TestMethod]
        public void GivenLoremIpsumGenerator_WhenUsingGenerateRandomNumberOfWords_ThenCorrectNumberOfWordsIsExpected()
        {
            for (var i = 0; i < 10; i++)
            {
                var result = LoremIpsumGenerator.GenerateRandomNumberOfWords();
                var numberOfWordsInResult = result.Split(' ').Length;

                Assert.IsTrue(numberOfWordsInResult >= 20 && numberOfWordsInResult <= 200);
            }
        }
    }
}
