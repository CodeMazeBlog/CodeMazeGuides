using UsingDirectiveForAdditionalTypes;

namespace Tests
{
    [TestClass]
    public class AdditionalTypesExamplesUnitTests
    {
        [TestMethod]
        public void GivenAListOfLocations_WhenListIsRetrieved_ThenListNotEmpty()
        {
            var locationsOfInterest = AdditionalTypesExamples.GetLocationsOfInterest();

            Assert.IsNotNull(locationsOfInterest);
            Assert.IsTrue(locationsOfInterest.Any());
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
            var listOfInts = AdditionalTypesExamples.GetArticleIDs();

            Assert.IsNotNull(listOfInts);
            Assert.IsTrue(listOfInts.Any());
        }
    }
}