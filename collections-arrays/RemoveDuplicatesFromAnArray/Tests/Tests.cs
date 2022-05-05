using RemoveDuplicatesFromAnArray;
using System.Linq;
using Xunit;

namespace Tests;

public class Tests
{
    public static readonly RemoveDuplicateElements _duplicatesRemoval = new RemoveDuplicateElements();

    [Fact]
    public void GivenAnArray_WhenUsingWithDistinctMethod_ThenReturnUniqueValues()
    {
        var repeatedStrArray = Enumerable.Repeat("it", 3).Concat(Enumerable.Repeat("jump", 3)).Concat(Enumerable.Repeat("it", 3)).ToArray();

        //Act
        var response = _duplicatesRemoval.WithDistinct_Method(repeatedStrArray);

        //Assert
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingGroupByandSelect_ThenReturnUniqueValues()
    {
        var repeatedStrArray = Enumerable.Repeat("it", 3).Concat(Enumerable.Repeat("jump", 3)).Concat(Enumerable.Repeat("it", 3)).ToArray();

        //Act
        var response = _duplicatesRemoval.WithGroupByandSelect(repeatedStrArray);

        //Assert
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingHashingMethod_ThenReturnUniqueValues()
    {
        var repeatedStrArray = Enumerable.Repeat("it", 3).Concat(Enumerable.Repeat("jump", 3)).Concat(Enumerable.Repeat("it", 3)).ToArray();

        //Act
        var response = _duplicatesRemoval.ByHashing(repeatedStrArray);

        //Assert
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingHashSet_ThenReturnUniqueValues()
    {
        var repeatedStrArray = Enumerable.Repeat("it", 3).Concat(Enumerable.Repeat("jump", 3)).Concat(Enumerable.Repeat("it", 3)).ToArray();

        //Act
        var response = _duplicatesRemoval.ByCreatingHashSet(repeatedStrArray);

        //Assert
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingForLoop_ThenReturnUniqueValues()
    {
        var repeatedStrArray = Enumerable.Repeat("it", 3).Concat(Enumerable.Repeat("jump", 3)).Concat(Enumerable.Repeat("it", 3)).ToArray();

        //Act
        var response = _duplicatesRemoval.UsingForLoop(repeatedStrArray);

        //Assert
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingForLoopWithDictionary_ThenReturnUniqueValues()
    {
        var repeatedStrArray = Enumerable.Repeat("it", 3).Concat(Enumerable.Repeat("jump", 3)).Concat(Enumerable.Repeat("it", 3)).ToArray();

        //Act
        var response = _duplicatesRemoval.UsingForLoopWithDictionary(repeatedStrArray);

        //Assert
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GivenAnArray_WhenUsingRecursion_ThenReturnUniqueValues()
    {
        var repeatedStrArray = Enumerable.Repeat("it", 3).Concat(Enumerable.Repeat("jump", 3)).Concat(Enumerable.Repeat("it", 3)).ToArray();

        //Act
        var response = _duplicatesRemoval.UsingRecursion(repeatedStrArray);

        //Assert
        Assert.Equal(2, response.Length);
    }
}

