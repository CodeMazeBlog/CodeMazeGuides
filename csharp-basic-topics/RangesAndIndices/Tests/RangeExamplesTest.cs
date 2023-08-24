using RangesAndIndicesExample;

namespace Tests;

public class RangeExamplesTest
{
    [Theory]
    [ClassData(typeof(TestData))]
    public void GivenStringArray_WhenGetAllIsInvoked_ThenReturnsAllElement(params string[] args)
    {
        var result = RangeExamples.GetAll(args);

        Assert.Equal(args, result);
    }
    
    [Theory]
    [ClassData(typeof(TestData))]
    public void GivenStringArray_WhenGetFirstTwoElementsIsInvoked_ThenReturnsTwoElementsFromStart(params string[] args)
    {
        var expected = new string[]{ args[0], args[1] };
        var result = RangeExamples.GetFirstTwoElements(args);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void GivenStringArray_WhenGetGetFirstThreeElementsIsInvoked_ThenReturnsThreeElementsFromStart(params string[] args)
    {
        var expected = new string[]{ args[0], args[1], args[2] };
        var result = RangeExamples.GetFirstThreeElements(args);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void GivenStringArray_WhenGetLastThreeElementsIsInvoked_ThenReturnsThreeElementsFromEnd(params string[] args)
    {
        var size = args.Length;
        var expected = new string[]{ args[size-3], args[size-2], args[size-1] };
        var result = RangeExamples.GetLastThreeElements(args);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void GivenStringArray_WhenGetThreeElementsFromMiddleIsInvoked_ThenReturnsThreeElementsFromMiddle(params string[] args)
    {
        var expected = new string[]{ args[3], args[4], args[5] };
        var result = RangeExamples.GetThreeElementsFromMiddle(args);

        Assert.Equal(expected, result);
    }
}