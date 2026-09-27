using AddValuesToArray;
using Xunit;
namespace Tests;

public class AddValuesToArrayUnitTest
{
    [Fact]
    public void GivenAnArraySize_WhenUsingArrayIndexInitializer_ThenValuesShouldBeAdded()
    {
        var array = AddValuesToArrayMethods.ArrayIndexInitializer(3);

        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
    }

    [Fact]
    public void GivenAnArraySize_WhenUsingSetValueMethod_ThenValuesShouldBeAdded()
    {
        var array = AddValuesToArrayMethods.SetValueMethod(3);

        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
    }
    [Fact]
    public void GivenAnArraySize_WhenUsingLinqList_ThenValuesShouldBeAdded()
    {
        var list = Enumerable.Range(0, 3).ToList();
        var array = AddValuesToArrayMethods.UsingList(list);

        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
    }

    [Fact]
    public void GivenAnArraySize_WhenUsingLinqConcat_ThenValuesShouldBeAdded()
    {
        var populatedArray = Enumerable.Range(0, 3).ToArray();
        var array = AddValuesToArrayMethods.LinqConcat(populatedArray);

        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
    }

    [Fact]
    public void GivenAnArraySize_WhenUsingArrayCopyTo_ThenValuesShouldBeAdded()
    {
        var populatedArray = Enumerable.Range(0, 3).ToArray();
        var array = AddValuesToArrayMethods.ArrayCopyTo(3, populatedArray);

        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
    }

    [Fact]
    public void GivenAnArray_WhenAppendingWithResize_ThenTheOriginalArrayIsUnchanged()
    {
        var original = new[] { 100, 101, 102 };
        var alias = original;

        var appended = AddValuesToArrayMethods.AppendWithResize(original, 103);

        Assert.Equal(4, appended.Length);
        Assert.Equal(3, alias.Length);
        Assert.False(ReferenceEquals(appended, alias));
    }

    [Fact]
    public void GivenAnArray_WhenAppendingWithResize_ThenTheValueIsAddedAtTheEnd()
    {
        var array = new[] { 100, 101, 102 };

        var appended = AddValuesToArrayMethods.AppendWithResize(array, 103);

        Assert.Equal(new[] { 100, 101, 102, 103 }, appended);
    }

    [Fact]
    public void GivenAnArray_WhenAppendingWithCollectionExpression_ThenANewArrayIsReturned()
    {
        var array = new[] { 100, 101, 102 };

        var appended = AddValuesToArrayMethods.AppendWithCollectionExpression(array, 103);

        Assert.Equal(new[] { 100, 101, 102, 103 }, appended);
        Assert.False(ReferenceEquals(array, appended));
    }

    [Fact]
    public void GivenAnArray_WhenUsingCollectionExpression_ThenACopyIsReturned()
    {
        var array = Enumerable.Range(0, 3).ToArray();

        var copy = AddValuesToArrayMethods.CollectionExpression(array);

        Assert.Equal(array, copy);
        Assert.False(ReferenceEquals(array, copy));
    }

    [Fact]
    public void GivenACount_WhenGrowingWithResizeAndWithList_ThenBothProduceTheSameArray()
    {
        var resized = AddValuesToArrayMethods.GrowWithResize(5);
        var listed = AddValuesToArrayMethods.GrowWithList(5);

        Assert.Equal(new[] { 0, 1, 2, 3, 4 }, resized);
        Assert.Equal(resized, listed);
    }
}
