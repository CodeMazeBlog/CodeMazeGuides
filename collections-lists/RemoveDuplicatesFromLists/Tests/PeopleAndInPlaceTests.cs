using RemoveDuplicatesFromLists;

namespace RemoveDuplicatesFromListsTests;

public class PeopleAndInPlaceTests
{
    [Fact]
    public void GivenAClass_WhenUsingDistinct_ThenKeepsEqualValuedPeople()
    {
        var people = new List<Person>
        {
            new() { Name = "Ann", Age = 30, Email = "ann@example.com" },
            new() { Name = "Ann", Age = 30, Email = "ann@example.com" }
        };

        var response = PeopleHelper.UsingDistinct(people);

        Assert.Equal(2, response.Count);
    }

    [Fact]
    public void GivenARecord_WhenUsingDistinct_ThenRemovesEqualValuedPeople()
    {
        var people = new List<PersonRecord>
        {
            new("Ann", 30, "ann@example.com"),
            new("Ann", 30, "ann@example.com")
        };

        var response = PeopleHelper.UsingDistinct(people);

        Assert.Single(response);
    }

    [Fact]
    public void GivenAClass_WhenUsingDistinctBy_ThenKeepsTheFirstPersonForEachEmail()
    {
        var first = new Person { Name = "Ann", Age = 30, Email = "ann@example.com" };
        var people = new List<Person>
        {
            first,
            new() { Name = "Ann Smith", Age = 31, Email = "ann@example.com" },
            new() { Name = "Bob", Age = 22, Email = "bob@example.com" }
        };

        var response = PeopleHelper.UsingDistinctBy(people);

        Assert.Equal(2, response.Count);
        Assert.Same(first, response[0]);
        Assert.Equal("bob@example.com", response[1].Email);
    }

    [Fact]
    public void WhenRemovingDuplicatesInPlace_ThenChangesTheSameListInstance()
    {
        var helper = new RemoveDuplicatesHelper<int>
        {
            ListWithDuplicates = new List<int>() { 1, 1, 2, 3, 4, 5 }
        };
        var sameList = helper.ListWithDuplicates;

        helper.RemoveDuplicatesInPlace();

        Assert.Same(sameList, helper.ListWithDuplicates);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, sameList);
    }

    [Fact]
    public void GivenDuplicatesSpreadThroughTheList_WhenRemovingDuplicatesInPlace_ThenKeepsFirstAppearanceOrder()
    {
        var helper = new RemoveDuplicatesHelper<int>
        {
            ListWithDuplicates = new List<int>() { 3, 1, 3, 2, 1, 4, 2, 5, 4 }
        };

        helper.RemoveDuplicatesInPlace();

        Assert.Equal(new[] { 3, 1, 2, 4, 5 }, helper.ListWithDuplicates);
    }
}
