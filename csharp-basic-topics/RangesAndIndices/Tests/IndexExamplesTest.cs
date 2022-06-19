using RangesAndIndicesExample;

namespace Tests;

public class IndexExamplesTest
{
    [Theory]
    [ClassData(typeof(TestData))]
    public void GivenStringArray_WhenGetFirstIsInvoked_ThenReturnsFirstElement(params string[] args)
    {
        var expected = args[0];
        var result = IndexExamples.GetFirst(args);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void GivenStringArray_WhenGetLastMethod1IsInvoked_ThenReturnsLastElement(params string[] args)
    {
        var expected = args[args.Length-1];
        var result = IndexExamples.GetLastMethod1(args);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void GivenStringArray_WhenGetLastMethod2IsInvoked_ThenReturnsLastElement(params string[] args)
    {
        var expected = args[args.Length-1];
        var result = IndexExamples.GetLastMethod2(args);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void GivenStringArray_WhenGetSecondLastIsInvoked_ThenReturnsSecondElementFromEnd(params string[] args)
    {
        var expected = args[args.Length-2];
        var result = IndexExamples.GetSecondLast(args);

        Assert.Equal(expected, result);
    }
}