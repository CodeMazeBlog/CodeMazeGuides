using CollectionsInCSharp;

namespace Tests
{
    public class GenericCollectionsTest
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

        [Fact]
        public void GivenEmptySortedList_WhenAddingToSortedList_ThenReturnsPopulatedSortedList()
        {
            var result = GenericCollections.CreateCountriesAndCapitals();

            Assert.IsType<SortedList<string, string>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenSortedList_WhenReadingFromSortedList_ThenReturnsPopulatedList()
        {
            var list = GenericCollections.CreateCountriesAndCapitals();
            var result = GenericCollections.ReadFromCountriesAndCapitals(list);

            Assert.IsType<List<string>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenEmptyDictionary_WhenAddingToDictionary_ThenReturnsPopulatedDictionary()
        {
            var result = GenericCollections.CreateCountriesWithRank();

            Assert.IsType<Dictionary<int, string>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenDictionary_WhenReadingFromDictionary_ThenReturnsPopulatedList()
        {
            var dict = GenericCollections.CreateCountriesWithRank();
            var result = GenericCollections.ReadFromCountriesWithRank(dict);

            Assert.IsType<List<string>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenEmptySortedSet_WhenAddingToSortedSet_ThenReturnsPopulatedSortedSet()
        {
            var result = GenericCollections.CreateNumbersSortedSet();

            Assert.IsType<SortedSet<int>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenSortedSet_WhenReadingFromSortedSet_ThenReturnsPopulatedList()
        {
            var sortedSet = GenericCollections.CreateNumbersSortedSet();
            var result = GenericCollections.ReadFromNumbersSortedSet(sortedSet);

            Assert.IsType<List<int>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenEmptyHashSet_WhenAddingToHashSet_ThenReturnsPopulatedHashSet()
        {
            var result = GenericCollections.CreateNumbersHashSet();

            Assert.IsType<HashSet<int>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenHashSet_WhenReadingFromHashSet_ThenReturnsPopulatedList()
        {
            var hashSet = GenericCollections.CreateNumbersHashSet();
            var result = GenericCollections.ReadFromNumbersHashSet(hashSet);

            Assert.IsType<List<int>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenEmptyQueue_WhenAddingToQueue_ThenReturnsPopulatedQueue()
        {
            var result = GenericCollections.CreateNumbersQueue();

            Assert.IsType<Queue<int>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenQueue_WhenReadingFromQueue_ThenReturnsAnInteger()
        {
            var queue = GenericCollections.CreateNumbersQueue();
            var result = GenericCollections.ReadFromNumbersQueue(queue);

            Assert.IsType<int>(result);
        }

        [Fact]
        public void GivenEmptyStack_WhenAddingToStack_ThenReturnsPopulatedStack()
        {
            var result = GenericCollections.CreateWordsStack();

            Assert.IsType<Stack<string>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenStack_WhenReadingFromStack_ThenReturnsAString()
        {
            var stack = GenericCollections.CreateWordsStack();
            var result = GenericCollections.ReadFromWordsStack(stack);

            Assert.IsType<string>(result);
        }
    }
}