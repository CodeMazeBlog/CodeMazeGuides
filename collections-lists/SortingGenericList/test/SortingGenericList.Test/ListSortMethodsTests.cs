namespace SortingGenericList.Test;

public class ListSortMethodsTests
{
    private static readonly int[] UnsortedListData = {2, 4, 1, 8, 9, 6, 5, 3, 7};

    [Fact]
    public void SortInPlaceWithSort_WhenCalled_ListIsSorted()
    {
        var list = new List<int>(UnsortedListData);
        list.Should().Equal(UnsortedListData).And.NotBeInAscendingOrder();

        ListSortMethods.SortListInPlaceWithSort(list);

        list.Should().NotEqual(UnsortedListData).And.BeInAscendingOrder();
    }

    [Fact]
    public void SortInPlaceWithSort_WhenCalledWithIComparer_ListIsSorted()
    {
        var list = new List<int>(UnsortedListData);
        list.Should().Equal(UnsortedListData).And.NotBeInDescendingOrder();

        ListSortMethods.SortListInPlaceWithSort(list, new DescendingIntComparison());

        list.Should().NotEqual(UnsortedListData).And.BeInDescendingOrder();
    }

    [Fact]
    public void SortInPlace_WhenCalledWithCompare_ListIsSorted()
    {
        var list = new List<int>(UnsortedListData);
        list.Should().Equal(UnsortedListData).And.NotBeInAscendingOrder();

        ListSortMethods.SortListInPlaceWithSort(list, (x, y) => y.CompareTo(x));

        list.Should().NotEqual(UnsortedListData).And.BeInDescendingOrder();
    }

    [Fact]
    public void SortWithOrder_WhenCalled_ListIsUnchanged()
    {
        var list = new List<int>(UnsortedListData);

        _ = ListSortMethods.SortListWithOrder(list).ToList();

        list.Should().Equal(UnsortedListData);
    }

    [Fact]
    public void SortWithOrder_WhenCalled_ResultingEnumerableIsSorted()
    {
        var list = new List<int>(UnsortedListData);

        var resultEnumerable = ListSortMethods.SortListWithOrder(list);

        resultEnumerable.Should().BeInAscendingOrder();
    }

    [Fact]
    public void SortWithOrderBy_WhenCalled_ListIsUnchanged()
    {
        var list = new List<int>(UnsortedListData);

        _ = ListSortMethods.SortListWithOrderBy(list, x => x).ToList();

        list.Should().Equal(UnsortedListData);
    }

    [Fact]
    public void SortWithOrderBy_WhenCalled_ResultingEnumerableIsSorted()
    {
        var list = new List<int>(UnsortedListData);

        var resultEnumerable = ListSortMethods.SortListWithOrderBy(list, x => x);

        resultEnumerable.Should().BeInAscendingOrder();
    }

    [Fact]
    public void SortWithOrderDescending_WhenCalled_ListIsUnchanged()
    {
        var list = new List<int>(UnsortedListData);

        _ = ListSortMethods.SortListWithOrderDescending(list).ToList();

        list.Should().Equal(UnsortedListData);
    }

    [Fact]
    public void SortWithOrderDescending_WhenCalled_ResultingEnumerableIsSortedDescending()
    {
        var list = new List<int>(UnsortedListData);

        var resultEnumerable = ListSortMethods.SortListWithOrderDescending(list);

        resultEnumerable.Should().BeInDescendingOrder();
    }

    [Fact]
    public void SortWithOrderByDescending_WhenCalled_ListIsUnchanged()
    {
        var list = new List<int>(UnsortedListData);

        _ = ListSortMethods.SortListWithOrderBy(list, x => x).ToList();

        list.Should().Equal(UnsortedListData);
    }

    [Fact]
    public void SortWithOrderByDescending_WhenCalled_ResultingEnumerableIsSortedDescending()
    {
        var list = new List<int>(UnsortedListData);

        var resultEnumerable = ListSortMethods.SortListWithOrderByDescending(list, x => x);

        resultEnumerable.Should().BeInDescendingOrder();
    }
}