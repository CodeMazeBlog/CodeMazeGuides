using RemoveDuplicatesFromLists;

namespace RemoveDuplicatesFromListsTests;

public class Tests
{
    RemoveDuplicatesHelper<int> _helper = new RemoveDuplicatesHelper<int>();

    public Tests()
    {
        _helper.ListWithDuplicates.Add(1);
        _helper.ListWithDuplicates.Add(2);
        _helper.ListWithDuplicates.Add(1);
        _helper.ListWithDuplicates.Add(2);
    }

    [Fact]
    public void WhenUsingDistinct_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingDistinct();

        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingGroupBy_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingGroupBy();

        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingUnion_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingUnion();

        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingHashSet_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingHashSet();

        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingDictionary_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingHashSet();

        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenRemoveDuplicatesIterativelly_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingEmptyList();

        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenRemoveDuplicatesManually_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingIterations();

        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingRecursion_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingRecursion();

        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenSorting_ThenRemovesDuplicates()
    {
        List<int> response = _helper.Sorting();

        Assert.Equal(2, response.Count);
    }
}