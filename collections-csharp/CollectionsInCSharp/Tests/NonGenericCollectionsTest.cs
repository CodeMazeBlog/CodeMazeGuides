namespace Tests
{
    public class NonGenericCollectionsTest
    {
        [Fact]
        public void GivenEmptyList_WhenAddingToList_ThenReturnsPopulatedList()
        {
            var result = GenericCollections.CreateCountries();

            Assert.IsType<List<string>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenList_WhenRemovingFromList_ThenReturnsPopulatedSortedList()
        {
            var countries = GenericCollections.CreateCountries();
            var result = GenericCollections.RemoveFromCountries(countries);

            Assert.IsType<List<string>>(result);
            Assert.NotEmpty(result);
        }
    }
}