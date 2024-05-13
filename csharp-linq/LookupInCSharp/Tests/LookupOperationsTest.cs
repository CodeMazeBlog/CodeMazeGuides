using LookupInCSharp;

namespace Tests;

public class LookupOperationsTest
{
    private static readonly List<Student> _students
        = [
            new("Kate Green", "Accounting"),
            new("Dan Sorla", "Economics"),
            new("Luna Delgrino", "Finance")
          ];

    private static readonly List<Student> _duplicateStudents
        = [
            new("Dan Sorla", "Investment Management"),
            new("Dan Sorla", "Economics"),
            new("Luna Delgrino", "Finance")
          ];

    [Fact]
    public void WhenCreateLookupWithKeyOnlyIsCalled_ThenReturnsLookup()
    {
        var expectedLookup = _students.ToLookup(s => s.Name);

        var lookup = LookupOperations.CreateLookupWithKeyOnly();

        Assert.Equal(expectedLookup, lookup);
    }

    [Fact]
    public void WhenCreateLookupWithKeysAndValuesIsCalled_ThenReturnsLookup()
    {
        var expectedLookup = _students.ToLookup(s => s.Name, s => s.Course);

        var lookup = LookupOperations.CreateLookupWithKeysAndValues();

        Assert.Equal(expectedLookup, lookup);
    }

    [Fact]
    public void WhenCreateLookupFromListWithDuplicateItemIsCalled_ThenReturnsLookup()
    {
        var expectedLookup = _duplicateStudents.ToLookup(s => s.Name, s => s.Course);

        var lookup = LookupOperations.CreateLookupFromListWithDuplicateItem();

        Assert.Equal(expectedLookup, lookup);
    }

    [Fact]
    public void WhenRetrieveValuesOfAKeyFromLookupIsCalled_ThenReturnsTheKeysValues()
    {
        IEnumerable<string> _expectedValues = ["Accounting"];

        var values = LookupOperations.RetrieveValuesOfAKeyFromLookup("Kate Green");

        Assert.Equal(_expectedValues, values);
    }

    [Fact]
    public void WhenRetrieveAllKeysFromLookupIsCalled_ThenReturnsAllKeys()
    {
        IEnumerable<string> _expectedKeys = ["Kate Green", "Dan Sorla", "Luna Delgrino"];

        var keys = LookupOperations.RetrieveAllKeysFromLookup();

        Assert.Equal(_expectedKeys, keys);
    }

    [Fact]
    public void WhenRetrieveAllValuesFromLookupIsCalled_ThenReturnsAllValues()
    {
        IEnumerable<string> _expectedValues = ["Accounting", "Economics", "Finance"];

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
        var result = LookupOperations.SearchForKeyInLookup("Michael Luna");

        Assert.False(result);
    }

    [Fact]
    public void WhenGetLookupCountIsCalled_ThenReturnsTheLookupCount()
    {
        var count = LookupOperations.GetLookupCount();

        Assert.Equal(3, count);
    }
}