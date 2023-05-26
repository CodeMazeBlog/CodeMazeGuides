using RemoveDuplicatesFromAnArray;
using Xunit;

namespace Tests;

public class Tests
{
    private readonly RemoveDuplicateElements _duplicatesRemoval;
    private int[] _arrayWithDuplicateValues;
    
    public Tests()
    {
        _duplicatesRemoval = new RemoveDuplicateElements();
        _arrayWithDuplicateValues = new int[] { 1,1,2,2 };
    }

    [Fact]
    public void GivenAnArray_WhenCallingDistinctLINQMethod_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.WithDistinctLINQMethod(_arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenCallingGroupByAndSelectLINQMethod_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.WithGroupByAndSelectLINQMethod(_arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenCallingHashingMethod_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.ByHashing(_arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingConversionToHashSetMethod_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.ByConvertingToHashSet(_arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenCallingIterationAndShiftingElementsMethod_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.IterationAndShiftingElements(_arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenCallingIterationWithDictionaryMethod_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.IterationWithDictionary(_arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingRecursiveMethod_ThenReturnUniqueValues()
    {
        var response = _duplicatesRemoval.RecursiveMethod(_arrayWithDuplicateValues);
        Assert.Equal(2, response.Length);
    }
}

