using UsingDirectiveForAdditionalTypes;

namespace Tests
{
    [TestClass]
    public class AdditionalTypesExamplesUnitTests
    {
        [TestMethod]
        public void GivenAListOfPoints_WhenListIsRetrieved_ThenListNotEmpty()
        {
            var pointsOfInterest = AdditionalTypesExamples.GetPointsOfInterest();

            Assert.IsNotNull(pointsOfInterest);
            Assert.IsTrue(pointsOfInterest.Any());
        }

        [TestMethod]
        public void GivenTitles_WhenTitlesAreRetrieved_ThenTheyAreNotEmpty()
        {
            var articleTitles = AdditionalTypesExamples.GetArticleTitles();

            Assert.IsNotNull(articleTitles);
            Assert.IsTrue(articleTitles.Any());
        }

        [TestMethod]
        public void GivenAListOfInts_WhenListIsRetrieved_ThenListNotEmpty_And_ListContainsNull()
        {
            var listOfInts = AdditionalTypesExamples.GetArticleTitles();

            Assert.IsNotNull(listOfInts);
            Assert.IsTrue(listOfInts.Any());
        }
    }
}