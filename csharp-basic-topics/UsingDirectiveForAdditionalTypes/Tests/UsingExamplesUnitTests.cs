using UsingDirectiveForAdditionalTypes;

namespace Tests
{
    [TestClass]
    public class UsingExamplesUnitTests
    {

        [TestMethod]
        public void GivenAListOfArticles_WhenListIsRetrieved_ThenListNotEmpty()
        {
            var articles = UsingExamples.GetArticles();

            Assert.IsNotNull(articles);
            Assert.IsTrue(articles.Any());
        }

        [TestMethod]
        public void Given4Ints_WhenGetMinimumIntegerIsCalled_ThenMinIsFound()
        {
            var expectedMinInt = -5;
            var minInt = UsingExamples.GetMinimumInteger(3, 7, expectedMinInt, 8);

            Assert.AreEqual(expectedMinInt, minInt);
        }
    }
}