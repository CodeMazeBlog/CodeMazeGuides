using System.Collections;

namespace ArrayListTests
{
    public class ArrayListTests
    {
        [Fact]
        public void GivenArrayList_WhenAddingItem_ThenItemAdded()
        {
            var arrayList = new ArrayList
            {
                "Hello",
                123,
                56.89
            };

            Assert.Equal(3, arrayList.Count);
        }

        [Fact]
        public void GivenArrayList_WhenAddRange_ThenAddItemsWithinRange()
        {
            var arrayList = new ArrayList
            {
                "Hello",
                123,
                56.89
            };
            var secondArrayList = new ArrayList
            {
                "World",
                456,
                59.95
            };

            arrayList.AddRange(secondArrayList);

            Assert.Equal(new ArrayList() { "Hello", 123, 56.89, "World", 456, 59.95 }, arrayList);
        }

        [Fact]
        public void GivenArrayList_WhenInsertingItemAtAnIndex_ThenItemInserted()
        {
            var arrayList = new ArrayList
            {
                "Hello",
                123,
                56.89
            };

            arrayList.Insert(1, "World");

            Assert.Equal("World", arrayList[1]);
        }

        [Fact]
        public void GivenArrayList_WhenInsertRange_ThenInsertItemsWithinRange()
        {
            var arrayList = new ArrayList
            {
                "Hello",
                123,
                56.89
            };
            var secondArrayList = new ArrayList
            {
                "World",
                456,
                59.95
            };

            arrayList.InsertRange(1, secondArrayList);

            Assert.Equal(new ArrayList() { "Hello", "World", 456, 59.95, 123, 56.89 }, arrayList);
        }

        [Fact]
        public void GivenArrayList_WhenRemovingItem_ThenItemRemoved()
        {
            var arrayList = new ArrayList() { "Hello", 42, "World" };

            arrayList.Remove(42);

            Assert.False(arrayList.Contains(42));
        }

        [Fact]
        public void GivenArrayList_WhenRemoveAt_ThenRemoveItemAtIndex()
        {
            var arrayList = new ArrayList() { "Apple", "Banana", "Orange" };

            arrayList.RemoveAt(1);

            Assert.False(arrayList.Contains("Banana"));
        }

        [Fact]
        public void GivenArrayList_WhenRemoveRange_ThenRemoveItemsWithinRange()
        {
            var arrayList = new ArrayList() { 1, 2, 3, 4, 5 };

            arrayList.RemoveRange(1, 3);

            Assert.Equal(new ArrayList() { 1, 5 }, arrayList);
        }

        [Fact]
        public void GivenArrayList_WhenClear_ThenRemoveAllItems()
        {
            var arrayList = new ArrayList() { 1, 2, 3, 4, 5 };

            arrayList.Clear();

            Assert.Empty(arrayList);
        }

        [Fact]
        public void GivenArrayList_WhenAccessingItem_ThenItemAccessed()
        {
            var arrayList = new ArrayList() { "Hello", 42, "World" };
            var element = arrayList[2];

            Assert.Equal("World", element);
        }

        [Fact]
        public void GivenArrayList_WhenSortingArrayList_ThenArrayListSorted()
        {
            var arrayList = new ArrayList() { 5, 2, 8, 1 };
            var expected = new ArrayList() { 1, 2, 5, 8 };

            arrayList.Sort();

            Assert.Equal(expected, arrayList);
        }

        [Fact]
        public void GivenArrayList_WhenReverseItemInArrayList_ThenArrayListReversed()
        {
            var arrayList = new ArrayList() { "Apple", "Banana", "Orange", "Grapes" };

            arrayList.Reverse();

            Assert.Equal(new ArrayList() { "Grapes", "Orange", "Banana", "Apple" }, arrayList);
        }

        [Fact]
        public void GivenArrayList_WhenSearchingAnItem_ThenReturnIndex()
        {
            var arrayList = new ArrayList() { "Apple", "Banana", "Orange" };
            var expectedIndex = 1;

            var actualIndex = arrayList.IndexOf("Banana");

            Assert.Equal(expectedIndex, actualIndex);
        }

        [Fact]
        public void GivenArrayList_WhenArrayListContainsAnItem_ThenReturnItem()
        {
            var arrayList = new ArrayList() { "Apple", "Banana", "Orange" };

            Assert.True(arrayList.Contains("Banana"));
            Assert.False(arrayList.Contains("Mango"));
        }

        [Fact]
        public void GivenArrayList_WhenSearchingAnItem_ThenReturnItemLastOccurrrenceIndex()
        {
            var arrayList = new ArrayList() { "Apple", "Banana", "Orange", "Banana", "Grapes" };

            var index = arrayList.LastIndexOf("Banana");

            Assert.Equal(3, index);
        }

        [Fact]
        public void GivenArrayList_WhenCloneArrayList_ThenCloneArrayList()
        {
            var originalArrayList = new ArrayList() { 1, 2, 3, "Hello" };

            var clonedArrayList = (ArrayList)originalArrayList.Clone();

            Assert.Equal(originalArrayList, clonedArrayList);
            Assert.NotSame(originalArrayList, clonedArrayList);
        }

        [Fact]
        public void GivenArrayList_WhenGetItemsWithinRange_ThenGetRange()
        {
            var arrayList = new ArrayList() { 1, 2, 3, 4, 5 };

            var arrayListRange = arrayList.GetRange(1, 3);

            Assert.Equal(new ArrayList { 2, 3, 4 }, arrayListRange);
        }
    }
}