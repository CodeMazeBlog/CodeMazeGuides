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
        var response = _helper.UsingDictionary();
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

    // The fixture above holds every duplicate at the end of the list, so a method that only
    // truncates the list passes it by accident. These cases put a duplicate at index 0.
    public static TheoryData<string> OrderKeepingMethods => new()
    {
        nameof(RemoveDuplicatesHelper<int>.UsingDistinct),
        nameof(RemoveDuplicatesHelper<int>.UsingGroupBy),
        nameof(RemoveDuplicatesHelper<int>.UsingUnion),
        nameof(RemoveDuplicatesHelper<int>.UsingDictionary),
        nameof(RemoveDuplicatesHelper<int>.UsingEmptyListWithContains),
        nameof(RemoveDuplicatesHelper<int>.UsingEmptyListWithAny),
        nameof(RemoveDuplicatesHelper<int>.UsingIterationsAndShifting),
        nameof(RemoveDuplicatesHelper<int>.UsingRecursion),
        nameof(RemoveDuplicatesHelper<int>.Sorting),
    };

    // A HashSet<T> does not guarantee its enumeration order, and swapping moves the last
    // item into the gap a duplicate leaves, so these are checked for content, not order.
    public static TheoryData<string> OrderFreeMethods => new()
    {
        nameof(RemoveDuplicatesHelper<int>.ConvertingToHashSet),
        nameof(RemoveDuplicatesHelper<int>.InitializingAHashSet),
        nameof(RemoveDuplicatesHelper<int>.UsingIterationsAndSwapping),
    };

    [Theory]
    [MemberData(nameof(OrderKeepingMethods))]
    public void GivenADuplicateAtIndexZero_WhenRemovingDuplicates_ThenKeepsEveryValueInOrder(string method)
    {
        var helper = new RemoveDuplicatesHelper<int>
        {
            ListWithDuplicates = new List<int>() { 1, 1, 2, 3, 4, 5 }
        };

        var response = Run(helper, method);

        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, response);
    }

    [Theory]
    [MemberData(nameof(OrderFreeMethods))]
    public void GivenADuplicateAtIndexZero_WhenRemovingDuplicates_ThenKeepsEveryValueOnce(string method)
    {
        var helper = new RemoveDuplicatesHelper<int>
        {
            ListWithDuplicates = new List<int>() { 1, 1, 2, 3, 4, 5 }
        };

        var response = Run(helper, method);

        Assert.Equal(5, response.Count);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, response.Order());
    }

    [Theory]
    [MemberData(nameof(OrderKeepingMethods))]
    [MemberData(nameof(OrderFreeMethods))]
    public void GivenDuplicatesSpreadThroughTheList_WhenRemovingDuplicates_ThenKeepsEveryValueOnce(string method)
    {
        var helper = new RemoveDuplicatesHelper<int>
        {
            ListWithDuplicates = new List<int>() { 3, 1, 3, 2, 1, 4, 2, 5, 4 }
        };

        var response = Run(helper, method);

        Assert.Equal(5, response.Count);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, response.Order());
    }

    [Theory]
    [MemberData(nameof(OrderKeepingMethods))]
    [MemberData(nameof(OrderFreeMethods))]
    public void GivenAZeroInTheList_WhenRemovingDuplicates_ThenKeepsTheZero(string method)
    {
        var helper = new RemoveDuplicatesHelper<int>
        {
            ListWithDuplicates = new List<int>() { 0, 1, 0, 2 }
        };

        var response = Run(helper, method);

        Assert.Equal(new[] { 0, 1, 2 }, response.Order());
    }

    private static List<int> Run(RemoveDuplicatesHelper<int> helper, string method) => method switch
    {
        nameof(helper.UsingDistinct) => helper.UsingDistinct(),
        nameof(helper.UsingGroupBy) => helper.UsingGroupBy(),
        nameof(helper.UsingUnion) => helper.UsingUnion(),
        nameof(helper.ConvertingToHashSet) => helper.ConvertingToHashSet(),
        nameof(helper.InitializingAHashSet) => helper.InitializingAHashSet(),
        nameof(helper.UsingDictionary) => helper.UsingDictionary(),
        nameof(helper.UsingEmptyListWithContains) => helper.UsingEmptyListWithContains(),
        nameof(helper.UsingEmptyListWithAny) => helper.UsingEmptyListWithAny(),
        nameof(helper.UsingIterationsAndShifting) => helper.UsingIterationsAndShifting(),
        nameof(helper.UsingIterationsAndSwapping) => helper.UsingIterationsAndSwapping(),
        nameof(helper.UsingRecursion) => helper.UsingRecursion(),
        nameof(helper.Sorting) => helper.Sorting(),
        _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
    };
}
