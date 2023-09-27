using RangesAndIndicesExample;

namespace Tests;

public class NameListExamplesTest
{
    [Theory]
    [ClassData(typeof(NameListTestData))]
    public void GivenNameList_WhenGetAllIsInvoked_ThenReturnsAllElement(NameList args)
    {
        var result = NameListExamples.GetAll(args);

        Assert.Equal(args, result);
    }
    
    [Theory]
    [ClassData(typeof(NameListTestData))]
    public void GivenNameList_WhenGetFirstTwoElementsIsInvoked_ThenReturnsTwoElementsFromStart(NameList args)
    {
        var expected = new string[]{ args[0], args[1] };
        var result = NameListExamples.GetFirstTwoElements(args);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(NameListTestData))]
    public void GivenNameList_WhenGetGetFirstThreeElementsIsInvoked_ThenReturnsThreeElementsFromStart(NameList args)
    {
        var expected = new string[]{ args[0], args[1], args[2] };
        var result = NameListExamples.GetFirstThreeElements(args);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(NameListTestData))]
    public void GivenNameList_WhenGetLastThreeElementsIsInvoked_ThenReturnsThreeElementsFromEnd(NameList args)
    {
        var size = args.Count;
        var expected = new string[]{ args[size-3], args[size-2], args[size-1] };
        var result = NameListExamples.GetLastThreeElements(args);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(NameListTestData))]
    public void GivenNameList_WhenGetThreeElementsFromMiddleIsInvoked_ThenReturnsThreeElementsFromMiddle(NameList args)
    {
        var expected = new string[]{ args[3], args[4], args[5] };
        var result = NameListExamples.GetThreeElementsFromMiddle(args);

        Assert.Equal(expected, result);
    }
}