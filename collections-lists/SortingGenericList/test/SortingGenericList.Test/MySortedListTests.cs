namespace SortingGenericList.Test;

public class MySortedListTests
{
    private static readonly int[] UnsortedListData = {2, 4, 1, 8, 9, 6, 5, 3, 7};
    private static readonly int[] SortedListData = {1, 2, 3, 4, 5, 6, 7, 8, 9};

    [Fact]
    public void Init_WhenCreatingNew_ListIsEmpty()
    {
        new MySortedList<int>().Should().BeEmpty();
    }

    [Fact]
    public void Init_WhenCalledWithCapacity_HasExpectedCapacity()
    {
        const int capacity = 10;
        var list = new MySortedList<int>(capacity);

        list.Capacity.Should().Be(capacity);
    }

    [Fact]
    public void Init_WhenCalledWithIEnumerable_HasExpectedValuesInSortedOrder()
    {
        var list = new MySortedList<int>(UnsortedListData);

        list.Should().BeEquivalentTo(UnsortedListData).And.BeInAscendingOrder();
    }

    [Fact]
    public void Init_WhenCalledWithICompare_HasExpectedSortOrder()
    {
        var list = new MySortedList<int>(UnsortedListData, new DescendingIntComparison());

        list.Should().BeInDescendingOrder();
    }

    [Fact]
    public void Add_WhenCalledWithSingleItem_CountIncreasesByOne()
    {
        var list = new MySortedList<int>();
        var currentCount = list.Count;
        list.Add(1);

        list.Count.Should().Be(currentCount + 1);
    }

    [Fact]
    public void Add_CallingWithItem_ListContainsItem()
    {
        const int expected = 10;
        var list = new MySortedList<int>();
        list.Should().NotContain(expected);

        list.Add(expected);

        list.Should().Contain(expected);
    }

    [Fact]
    public void Indexer_WhenCalling_ReturnsProperItem()
    {
        var list = new MySortedList<int>(SortedListData);

        list[2].Should().Be(SortedListData[2]);
    }

    [Fact]
    public void Indexer_WhenCalledWithInvalidIndex_ThrowsOutOfRange()
    {
        this.Invoking(_ => new MySortedList<int>()[1]).Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Indexer_WhenCalledWithNegativeIndex_ThrowsOutOfRange()
    {
        this.Invoking(_ => new MySortedList<int>()[-1]).Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Add_WhenCalledWithSortedData_ListIsSorted()
    {
        SortedListData.Should().BeInAscendingOrder();

        var list = new MySortedList<int>();
        foreach (var item in SortedListData) list.Add(item);

        list.Should().BeInAscendingOrder();
    }

    [Fact]
    public void Init_WhenCalledWithSortedData_ListIsSorted()
    {
        SortedListData.Should().BeInAscendingOrder();

        var list = new MySortedList<int>(SortedListData);

        list.Should().BeInAscendingOrder();
    }

    [Fact]
    public void AddRange_WhenCalledWithSortedData_ListIsSorted()
    {
        SortedListData.Should().BeInAscendingOrder();

        var list = new MySortedList<int>();
        list.AddRange(SortedListData);

        list.Should().BeInAscendingOrder();
    }

    [Fact]
    public void Add_WhenCalledWithUnsortedData_ListIsSorted()
    {
        UnsortedListData.Should().NotBeInAscendingOrder().And.NotBeInDescendingOrder();

        var list = new MySortedList<int>();
        foreach (var item in UnsortedListData) list.Add(item);

        list.Should().BeInAscendingOrder();
    }

    [Fact]
    public void Init_WhenWithUnsortedData_ListIsSorted()
    {
        UnsortedListData.Should().NotBeInAscendingOrder().And.NotBeInDescendingOrder();

        var list = new MySortedList<int>(UnsortedListData);

        list.Should().BeInAscendingOrder();
    }

    [Fact]
    public void AddRange_CallingWithUnsortedData_ListIsSorted()
    {
        UnsortedListData.Should().NotBeInAscendingOrder().And.NotBeInDescendingOrder();

        var list = new MySortedList<int>();
        list.AddRange(UnsortedListData);

        list.Should().BeInAscendingOrder();
    }

    [Fact]
    public void Clear_WhenCalled_ClearsList()
    {
        const int count = 10;
        var list = new MySortedList<int>(Enumerable.Range(0, count).Select(x => x));
        Assert.Equal(count, list.Count);

        list.Clear();

        list.Should().BeEmpty();
    }

    [Fact]
    public void Contains_CallingWithContainedItem_ReturnsTrue()
    {
        var list = new MySortedList<int> {10};

        list.Contains(10).Should().BeTrue();
    }

    [Fact]
    public void Contains_CallingWithNonContainedItem_ReturnsFalse()
    {
        var list = new MySortedList<int> {42};

        list.Contains(10).Should().BeFalse();
    }

    [Fact]
    public void Remove_CallingWithNonExistentItem_ReturnsFalse()
    {
        var list = new MySortedList<int> {1, 2};

        list.Remove(10).Should().BeFalse();
    }

    [Fact]
    public void Remove_CallingWithExistentItem_ReturnsTrue()
    {
        var list = new MySortedList<int> {1, 2, 10};

        list.Remove(10).Should().BeTrue();
    }

    [Fact]
    public void Remove_CallingWithExistentItem_ReducesCount()
    {
        var list = new MySortedList<int> {0, 1, 2, 3, 4};
        var currentCount = list.Count;
        list.Remove(1);

        list.Count.Should().Be(currentCount - 1);
    }

    [Fact]
    public void Remove_CallingWithExistentItem_RemovesItem()
    {
        const int itemToRemove = 10;

        var list = new MySortedList<int> {1, 2, itemToRemove};
        list.Should().Contain(itemToRemove);

        list.Remove(itemToRemove);

        list.Should().NotContain(itemToRemove);
    }

    [Fact]
    public void CopyTo_Calling_CopiedArrayIsExpected()
    {
        var list = new MySortedList<int>(SortedListData);
        var dest = new int[SortedListData.Length];

        list.CopyTo(dest, 0);

        dest.Should().BeEquivalentTo(list).And.BeEquivalentTo(SortedListData);
    }

    [Fact]
    public void CopyTo_CallingWithSpan_CopiedArrayIsExpected()
    {
        var expectedList = new[] {0, 1, 2, 3, 4};
        var list = new MySortedList<int>(expectedList);

        var dest = new int[expectedList.Length];
        list.CopyTo(dest.AsSpan());

        dest.Should().BeEquivalentTo(list).And.BeEquivalentTo(expectedList);
    }

    [Fact]
    public void ToArray_WhenCalling_ResultArrayIsExpected()
    {
        var expectedList = new[] {0, 1, 2, 3, 4};
        var list = new MySortedList<int>(expectedList);

        var dest = list.ToArray();

        dest.Should().BeEquivalentTo(list).And.BeEquivalentTo(expectedList);
    }

    [Fact]
    public void Init_WhenCallingWithUnsortedStrings_ListIsSorted()
    {
        var unsortedList = new[] {"Bill", "Dan", "Adam", "Chuck"};

        var list = new MySortedList<string>(unsortedList);

        list.Should().BeInAscendingOrder();
    }

    [Fact]
    public void Insert_Calling_ThrowsNotSupportedException()
    {
        var sortedList = new MySortedList<int> {0, 1, 2, 3, 4};

        sortedList.Invoking(list => list.Insert(2, 42)).Should().Throw<NotSupportedException>();
    }

    [Fact]
    public void Indexer_AttemptingToSet_ThrowsNotSupportedException()
    {
        var sortedList = new MySortedList<int> {0, 1, 2, 3, 4};

        sortedList.Invoking(list => list[2] = 42).Should().Throw<NotSupportedException>();
    }

    [Fact]
    public void IndexOf_WhenItemIsPresent_ShouldReturnCorrectIndex()
    {
        var sortedList = new MySortedList<int>(new[] {1, 2, 3});

        sortedList.IndexOf(2).Should().Be(1);
    }

    [Fact]
    public void IndexOf_WhenItemIsNotPresent_ShouldReturnNegativeOne()
    {
        var sortedList = new MySortedList<int>(new[] {1, 2, 3});

        sortedList.IndexOf(4).Should().Be(-1);
    }

    [Fact]
    public void RemoveAt_WhenIndexIsValid_ShouldRemoveItemAtGivenIndex()
    {
        var sortedList = new MySortedList<int>(new[] {1, 2, 3});

        sortedList.RemoveAt(1);

        sortedList.Contains(2).Should().BeFalse();
    }

    [Fact]
    public void RemoveAt_WhenIndexIsInvalid_ShouldThrowException()
    {
        var sortedList = new MySortedList<int>(new[] {1, 2, 3});

        sortedList.Invoking(list => list.RemoveAt(3)).Should().Throw<ArgumentOutOfRangeException>();
    }

    private sealed class DescendingIntComparison : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }
}