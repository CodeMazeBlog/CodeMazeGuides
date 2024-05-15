using LookupInCSharp;

namespace Tests;

public class LookupOperationsTest
{
    private static readonly List<Student> _students
        = [
            new("Dan Sorla", "Accounting"),
            new("Dan Sorla", "Economics"),
            new("Luna Delgrino", "Finance"),
            new("Kate Green", "Investment Management")
          ];

    [Fact]
    public void WhenCreateLookupIsCalled_ThenReturnsLookup()
    {
        var expectedLookup = _students.ToLookup(s => s.Name, s => s.Course);

        var lookup = LookupOperations.CreateLookup();

        Assert.Equal(expectedLookup, lookup);
    }

    [Fact]
    public void WhenRetrieveValuesOfAKeyFromLookupIsCalled_ThenReturnsTheKeysValues()
    {
        IEnumerable<string> _expectedValues = ["Investment Management"];

        var values = LookupOperations.RetrieveValuesOfAKeyFromLookup("Kate Green");

        Assert.Equal(_expectedValues, values);
    }

    [Fact]
    public void WhenRetrieveAllKeysFromLookupIsCalled_ThenReturnsAllKeys()
    {
        IEnumerable<string> _expectedKeys = ["Dan Sorla", "Luna Delgrino", "Kate Green"];

        var keys = LookupOperations.RetrieveAllKeysFromLookup();

        Assert.Equal(_expectedKeys, keys);
    }

    [Fact]
    public void WhenRetrieveAllValuesFromLookupIsCalled_ThenReturnsAllValues()
    {
        IEnumerable<string> _expectedValues = ["Accounting", "Economics", "Finance", "Investment Management"];

        var values = LookupOperations.RetrieveAllValuesFromLookup();

        Assert.Equal(_expectedValues, values);
    }

    [Fact]
    public void GivenKeyThatExists_WhenSearchForKeyInLookupIsCalled_ThenReturnsTrue()
    {
        var result = LookupOperations.SearchForKeyInLookup("Luna Delgrino");

        Assert.True(result);
    }

    [Fact]
    public void GivenKeyThatDoesNotExists_WhenSearchForKeyInLookupIsCalled_ThenReturnsFalse()
    {
        var result = LookupOperations.SearchForKeyInLookup("Michael Sorla");

        Assert.False(result);
    }

    [Fact]
    public void WhenGetLookupCountIsCalled_ThenReturnsTheLookupCount()
    {
        var count = LookupOperations.GetLookupCount();

        Assert.Equal(3, count);
    }
}