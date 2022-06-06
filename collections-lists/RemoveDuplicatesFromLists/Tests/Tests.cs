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
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingGroupBy_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingGroupBy();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingUnion_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingUnion();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingHashSet_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingHashSet();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingDictionary_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingHashSet();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingEmptyList_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingEmptyList();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingIterations_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingIterations();

        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingIterationsAndSwapping_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingIterationsAndSwapping();

        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingRecursion_ThenRemovesDuplicates()
    {
        List<int> response = _helper.UsingRecursion();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenSorting_ThenRemovesDuplicates()
    {
        List<int> response = _helper.Sorting();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }
}