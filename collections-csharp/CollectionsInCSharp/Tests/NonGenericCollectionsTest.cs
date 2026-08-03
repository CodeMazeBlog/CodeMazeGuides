using CollectionsInCSharp;
using System.Collections;

namespace Tests
{
    public class NonGenericCollectionsTest
    {
        [Fact]
        public void GivenEmptyArrayList_WhenAddingToArrayList_ThenReturnsPopulatedArrayList()
        {
            var result = NonGenericCollections.CreateDetailsList();

            Assert.IsType<ArrayList>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenArrayList_WhenReadingFromArrayList_ThenReturnsAnObject()
        {
            var details = NonGenericCollections.CreateDetailsList();
            var  result = NonGenericCollections.ReadFromDetailsList(details);

            Assert.NotEmpty(result);
            Assert.IsType<ArrayList>(result);
        }

        [Fact]
        public void GivenEmptyHashTable_WhenAddingToHashTable_ThenReturnsPopulatedHashTable()
        {
            var result = NonGenericCollections.CreateDetailsHashTable();

            Assert.IsType<Hashtable>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenHashTable_WhenReadingFromHashTable_ThenReturnsAnArrayList()
        {
            var details = NonGenericCollections.CreateDetailsHashTable();
            var result = NonGenericCollections.ReadFromDetailsHashTable(details);

            Assert.IsType<ArrayList>(result);
        }

        [Fact]
        public void GivenEmptySortedList_WhenAddingToPopulatingList_ThenReturnsPopulatedSortedList()
        {
            var result = NonGenericCollections.CreateNumbersSortedList();

            Assert.IsType<SortedList>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenSortedList_WhenReadingFromSortedList_ThenReturnsAnArrayList()
        {
            var numbers = NonGenericCollections.CreateNumbersSortedList();
            var result = NonGenericCollections.ReadFromNumbersSortedList(numbers);

            Assert.IsType<ArrayList>(result);
        }

        [Fact]
        public void GivenEmptyStack_WhenAddingToStack_ThenReturnsPopulatedStack()
        {
            var result = NonGenericCollections.CreateDetailsStack();

            Assert.IsType<Stack>(result);
        }

        [Fact]
        public void GivenStack_WhenReadingFromStack_ThenReturnsAnArrayList()
        {
            var details = NonGenericCollections.CreateDetailsStack();
            var result = NonGenericCollections.ReadFromDetailsStack(details);

            Assert.IsType<ArrayList>(result);
        }

        [Fact]
        public void GivenEmptyQueue_WhenAddingToQueue_ThenReturnsPopulatedQueue()
        {
            var result = NonGenericCollections.CreateDetailsQueue();

            Assert.IsType<Queue>(result);
        }

        [Fact]
        public void GivenQueue_WhenReadingFromQueue_ThenReturnsAnArrayList()
        {
            var details = NonGenericCollections.CreateDetailsQueue();
            var result = NonGenericCollections.ReadFromDetailsQueue(details);

            Assert.IsType<ArrayList>(result);
        }
    }
}