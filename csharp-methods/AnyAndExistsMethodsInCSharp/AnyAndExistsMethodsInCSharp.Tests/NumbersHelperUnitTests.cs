namespace AnyAndExistsMethodsInCSharp.Tests;

public class NumbersHelperUnitTests
{
    [Fact]
    public void WhenProvidingAnEmptyCollection_ThenReturnTrue()
    {
        int[] numbers = [];

        Assert.True(NumbersHelper.CheckIfArrayIsEmpty(numbers));
    }

    [Fact]
    public void WhenProvidingACollectionWithPositiveNumbers_ThenReturnTrue()
    {
        List<int> numbers = [-10, 0, 1];

        Assert.True(NumbersHelper.CheckIfListContainsPositiveNumbersAny(numbers));
    }

    [Fact]
    public void WhenProvidingAListWithNoPositiveNumbers_ThenReturnFalse()
    {
        List<int> numbers = [-10, 0, -1];

        Assert.False(NumbersHelper.CheckIfListContainsPositiveNumbersAny(numbers));
    }

    [Fact]
    public void WhenProvidingAListWithPositiveNumbers_ThenExistsReturnsTrue()
    {
        List<int> numbers = [-10, 0, 1];

        Assert.True(NumbersHelper.CheckIfListContainsPositiveNumbersExists(numbers));
    }

    [Fact]
    public void WhenProvidingAListWithNoPositiveNumbers_ThenExistsReturnsFalse()
    {
        List<int> numbers = [-10, 0, -1];

        Assert.False(NumbersHelper.CheckIfListContainsPositiveNumbersExists(numbers));
    }

    [Fact]
    public void WhenProvidingAnArrayWithPositiveNumbers_ThenArrayExistsReturnsTrue()
    {
        int[] numbers = [-10, 0, 1];

        Assert.True(NumbersHelper.CheckIfArrayContainsPositiveNumbersExists(numbers));
    }

    [Fact]
    public void WhenListIsNull_ThenAnyThrowsArgumentNullException()
    {
        List<int> numbers = null!;

        Assert.Throws<ArgumentNullException>(() => NumbersHelper.CheckIfListContainsPositiveNumbersAny(numbers));
    }

    [Fact]
    public void WhenListIsNull_ThenExistsThrowsNullReferenceException()
    {
        List<int> numbers = null!;

        Assert.Throws<NullReferenceException>(() => NumbersHelper.CheckIfListContainsPositiveNumbersExists(numbers));
    }
}
