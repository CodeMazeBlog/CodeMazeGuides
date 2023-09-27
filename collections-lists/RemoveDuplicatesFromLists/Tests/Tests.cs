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
        var response = _helper.UsingDistinct();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingGroupBy_ThenRemovesDuplicates()
    {
        var response = _helper.UsingGroupBy();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingUnion_ThenRemovesDuplicates()
    {
        var response = _helper.UsingUnion();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingHashSet_ThenRemovesDuplicates()
    {
        var response = _helper.ConvertingToHashSet();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenInitializingHashSet_ThenRemovesDuplicates()
    {
        var response = _helper.InitializingAHashSet();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingDictionary_ThenRemovesDuplicates()
    {
        var response = _helper.ConvertingToHashSet();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingEmptyListWithContains_ThenRemovesDuplicates()
    {
        var response = _helper.UsingEmptyListWithContains();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingEmptyListWithContainsAny_ThenRemovesDuplicates()
    {
        var response = _helper.UsingEmptyListWithAny();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingIterations_ThenRemovesDuplicates()
    {
        var response = _helper.UsingIterationsAndShifting();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingIterationsAndSwapping_ThenRemovesDuplicates()
    {
        var response = _helper.UsingIterationsAndSwapping();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenUsingRecursion_ThenRemovesDuplicates()
    {
        var response = _helper.UsingRecursion();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void WhenSorting_ThenRemovesDuplicates()
    {
        var response = _helper.Sorting();
        var unique = response.GroupBy(p => p).All(g => g.Count() == 1);

        Assert.True(unique);
        Assert.Equal(2, response.Count);
    }
}