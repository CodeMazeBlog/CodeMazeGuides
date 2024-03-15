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
        var array = AddValuesToArrayMethods.UsingList(3, list);

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
}