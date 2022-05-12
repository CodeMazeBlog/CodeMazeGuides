using RemoveDuplicatesFromAnArray;
using Xunit;

namespace Tests;

public class Tests
{
    private readonly RemoveDuplicateElements _duplicatesRemoval;
    string[] arrayWithDuplicateValues;
    public Tests()
    {
        _duplicatesRemoval = new RemoveDuplicateElements();
        arrayWithDuplicateValues = new string[] { "value1", "value1", "value2", "value2" };
    }

    [Fact]
    public void GivenAnArray_WhenUsingWithDistinctLINQMethod_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.WithDistinctLINQMethod(arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingGroupByAndSelectLINQMethod_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.WithGroupByAndSelectLINQMethod(arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingHashingMethod_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.ByHashing(arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingHashSet_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.ByCreatingHashSet(arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingForLoopAndShiftingElements_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.UsingForLoopAndShiftingElements(arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingForLoopWithDictionary_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.UsingForLoopWithDictionary(arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingRecursion_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.UsingRecursion(arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }
}

