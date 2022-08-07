using AddValuesToArray;
using Xunit;
namespace Tests;

public class AddValuesToArrayUnitTest
{
    [Fact]
    public void GivenAnArraySize_WhenUsingArrayIndexInitilizer_ThenValuesShouldBeAdded()
    {
        var array = AddValuesToArrayMethods.ArrayIndexInitilizer(3);

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
        var array = AddValuesToArrayMethods.LinqList(3);

        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
    }

    [Fact]
    public void GivenAnArraySize_WhenUsingLinqConcat_ThenValuesShouldBeAdded()
    {
        var array = AddValuesToArrayMethods.LinqConcat(3);

        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
    }

    [Fact]
    public void GivenAnArraySize_WhenUsingLinqAppend_ThenValuesShouldBeAdded()
    {
        var array = AddValuesToArrayMethods.LinqAppend(3);

        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
    }

    [Fact]
    public void GivenAnArraySize_WhenUsingArrayResize_ThenValuesShouldBeAdded()
    {
        var array = AddValuesToArrayMethods.ArrayResize(3);

        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
    }
}