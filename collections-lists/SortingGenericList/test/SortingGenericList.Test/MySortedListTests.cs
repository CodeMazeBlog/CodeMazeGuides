namespace SortingGenericList.Test;

public class MySortedListTests
{
    private static readonly int[] UnsortedListData = [2, 4, 1, 8, 9, 6, 5, 3, 7];
    private static readonly int[] SortedListData = [1, 2, 3, 4, 5, 6, 7, 8, 9];

    private static void AssertAscending<T>(IEnumerable<T> items) => Assert.Equal(items.Order(), items);

    private static void AssertNotSorted(int[] items)
    {
        Assert.NotEqual(items.Order(), items);
        Assert.NotEqual(items.OrderDescending(), items);
    }

    [Fact]
    public void Init_WhenCreatingNew_ListIsEmpty()
    {
        Assert.Empty(new MySortedList<int>());
    }

    [Fact]
    public void Init_WhenCalledWithCapacity_HasExpectedCapacity()
    {
        const int capacity = 10;
        var list = new MySortedList<int>(capacity);

        Assert.Equal(capacity, list.Capacity);
    }

    [Fact]
    public void Init_WhenCalledWithIEnumerable_HasExpectedValuesInSortedOrder()
    {
        var list = new MySortedList<int>(UnsortedListData);

        Assert.Equal(UnsortedListData.Order(), list);
    }

    [Fact]
    public void Init_WhenCalledWithICompare_HasExpectedSortOrder()
    {
        var list = new MySortedList<int>(UnsortedListData, new DescendingIntComparison());

        Assert.Equal(UnsortedListData.OrderDescending(), list);
    }

    [Fact]
    public void Add_WhenCalledWithSingleItem_CountIncreasesByOne()
    {
        var list = new MySortedList<int>();
        var currentCount = list.Count;
        list.Add(1);

        Assert.Equal(currentCount + 1, list.Count);
    }

    [Fact]
    public void Add_CallingWithItem_ListContainsItem()
    {
        const int expected = 10;
        var list = new MySortedList<int>();
        Assert.DoesNotContain(expected, list);

        list.Add(expected);

        Assert.Contains(expected, list);
    }

    [Fact]
    public void Indexer_WhenCalling_ReturnsProperItem()
    {
        var list = new MySortedList<int>(SortedListData);

        Assert.Equal(SortedListData[2], list[2]);
    }

    [Fact]
    public void Indexer_WhenCalledWithInvalidIndex_ThrowsOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new MySortedList<int>()[1]);
    }

    [Fact]
    public void Indexer_WhenCalledWithNegativeIndex_ThrowsOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new MySortedList<int>()[-1]);
    }

    [Fact]
    public void Add_WhenCalledWithSortedData_ListIsSorted()
    {
        AssertAscending(SortedListData);

        var list = new MySortedList<int>();
        foreach (var item in SortedListData) list.Add(item);

        AssertAscending(list);
    }

    [Fact]
    public void Init_WhenCalledWithSortedData_ListIsSorted()
    {
        AssertAscending(SortedListData);

        var list = new MySortedList<int>(SortedListData);

        AssertAscending(list);
    }

    [Fact]
    public void AddRange_WhenCalledWithSortedData_ListIsSorted()
    {
        AssertAscending(SortedListData);

        var list = new MySortedList<int>();
        list.AddRange(SortedListData);

        AssertAscending(list);
    }

    [Fact]
    public void Add_WhenCalledWithUnsortedData_ListIsSorted()
    {
        AssertNotSorted(UnsortedListData);

        var list = new MySortedList<int>();
        foreach (var item in UnsortedListData) list.Add(item);

        AssertAscending(list);
    }

    [Fact]
    public void Init_WhenWithUnsortedData_ListIsSorted()
    {
        AssertNotSorted(UnsortedListData);

        var list = new MySortedList<int>(UnsortedListData);

        AssertAscending(list);
    }

    [Fact]
    public void AddRange_CallingWithUnsortedData_ListIsSorted()
    {
        AssertNotSorted(UnsortedListData);

        var list = new MySortedList<int>();
        list.AddRange(UnsortedListData);

        AssertAscending(list);
    }

    [Fact]
    public void Add_WhenCalledWithRandomData_MatchesListSort()
    {
        var random = new Random(42);
        var data = Enumerable.Range(0, 1_000).Select(_ => random.Next(100)).ToArray();

        var list = new MySortedList<int>();
        foreach (var item in data) list.Add(item);

        var expected = new List<int>(data);
        expected.Sort();

        Assert.Equal(expected, list);
    }

    [Fact]
    public void Clear_WhenCalled_ClearsList()
    {
        const int count = 10;
        var list = new MySortedList<int>(Enumerable.Range(0, count));
        Assert.Equal(count, list.Count);

        list.Clear();

        Assert.Empty(list);
    }

    [Fact]
    public void Contains_CallingWithContainedItem_ReturnsTrue()
    {
        var list = new MySortedList<int> {10};

        var found = list.Contains(10);

        Assert.True(found);
    }

    [Fact]
    public void Contains_CallingWithNonContainedItem_ReturnsFalse()
    {
        var list = new MySortedList<int> {42};

        var found = list.Contains(10);

        Assert.False(found);
    }

    [Fact]
    public void Remove_CallingWithNonExistentItem_ReturnsFalse()
    {
        var list = new MySortedList<int> {1, 2};

        Assert.False(list.Remove(10));
    }

    [Fact]
    public void Remove_CallingWithExistentItem_ReturnsTrue()
    {
        var list = new MySortedList<int> {1, 2, 10};

        Assert.True(list.Remove(10));
    }

    [Fact]
    public void Remove_CallingWithExistentItem_ReducesCount()
    {
        var list = new MySortedList<int> {0, 1, 2, 3, 4};
        var currentCount = list.Count;
        list.Remove(1);

        Assert.Equal(currentCount - 1, list.Count);
    }

    [Fact]
    public void Remove_CallingWithExistentItem_RemovesItem()
    {
        const int itemToRemove = 10;

        var list = new MySortedList<int> {1, 2, itemToRemove};
        Assert.Contains(itemToRemove, list);

        list.Remove(itemToRemove);

        Assert.DoesNotContain(itemToRemove, list);
    }

    [Fact]
    public void CopyTo_Calling_CopiedArrayIsExpected()
    {
        var list = new MySortedList<int>(SortedListData);
        var dest = new int[SortedListData.Length];

        list.CopyTo(dest, 0);

        Assert.Equal(list, dest);
        Assert.Equal(SortedListData, dest);
    }

    [Fact]
    public void CopyTo_CallingWithSpan_CopiedArrayIsExpected()
    {
        int[] expectedList = [0, 1, 2, 3, 4];
        var list = new MySortedList<int>(expectedList);

        var dest = new int[expectedList.Length];
        list.CopyTo(dest.AsSpan());

        Assert.Equal(list, dest);
        Assert.Equal(expectedList, dest);
    }

    [Fact]
    public void ToArray_WhenCalling_ResultArrayIsExpected()
    {
        int[] expectedList = [0, 1, 2, 3, 4];
        var list = new MySortedList<int>(expectedList);

        var dest = list.ToArray();

        Assert.Equal(list, dest);
        Assert.Equal(expectedList, dest);
    }

    [Fact]
    public void Init_WhenCallingWithUnsortedStrings_ListIsSorted()
    {
        string[] unsortedList = ["Bill", "Dan", "Adam", "Chuck"];

        var list = new MySortedList<string>(unsortedList);

        Assert.Equal(["Adam", "Bill", "Chuck", "Dan"], list);
    }

    [Fact]
    public void Insert_Calling_ThrowsNotSupportedException()
    {
        var sortedList = new MySortedList<int> {0, 1, 2, 3, 4};

        Assert.Throws<NotSupportedException>(() => sortedList.Insert(2, 42));
    }

    [Fact]
    public void Indexer_AttemptingToSet_ThrowsNotSupportedException()
    {
        var sortedList = new MySortedList<int> {0, 1, 2, 3, 4};

        Assert.Throws<NotSupportedException>(() => sortedList[2] = 42);
    }

    [Fact]
    public void IndexOf_WhenItemIsPresent_ShouldReturnCorrectIndex()
    {
        var sortedList = new MySortedList<int>([1, 2, 3]);

        Assert.Equal(1, sortedList.IndexOf(2));
    }

    [Fact]
    public void IndexOf_WhenItemIsDuplicated_ShouldReturnFirstIndex()
    {
        var sortedList = new MySortedList<int>([1, 5, 5, 5, 5, 5, 5, 9]);

        Assert.Equal(1, sortedList.IndexOf(5));
    }

    [Fact]
    public void IndexOf_WhenItemIsNotPresent_ShouldReturnNegativeOne()
    {
        var sortedList = new MySortedList<int>([1, 2, 3]);

        Assert.Equal(-1, sortedList.IndexOf(4));
    }

    [Fact]
    public void RemoveAt_WhenIndexIsValid_ShouldRemoveItemAtGivenIndex()
    {
        var sortedList = new MySortedList<int>([1, 2, 3]);

        sortedList.RemoveAt(1);

        var found = sortedList.Contains(2);

        Assert.False(found);
    }

    [Fact]
    public void RemoveAt_WhenIndexIsInvalid_ShouldThrowException()
    {
        var sortedList = new MySortedList<int>([1, 2, 3]);

        Assert.Throws<ArgumentOutOfRangeException>(() => sortedList.RemoveAt(3));
    }

    private sealed class DescendingIntComparison : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }
}
