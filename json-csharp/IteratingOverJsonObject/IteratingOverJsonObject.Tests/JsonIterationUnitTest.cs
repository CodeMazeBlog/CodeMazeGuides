namespace IteratingOverJsonObject.Tests;

public class JsonIterationUnitTest
{
    private readonly JsonIteration _jsonIteration;

    public JsonIterationUnitTest()
    {
        _jsonIteration = new JsonIteration();
    }

    [Theory]
    [InlineData(5)]
    public void WhenJsonDataIsDynamicallyRead_ThenIncreaseCount(int expectedCount)
    {
        var count = _jsonIteration.IterateOverJsonDynamically();

        Assert.Equal(expectedCount, count);
    }

    [Theory]
    [InlineData(5)]
    public void WhenJArrayIsUsed_ThenIncreaseCount(int expectedCount)
    {
        var count= _jsonIteration.IterateUsingJArray();

        Assert.Equal(expectedCount, count);
    }

    [Theory]
    [InlineData(5)]
    public void WhenStaticListIsUsed_ThenReturnListOfEmployees(int expectedCount)
    {
        var employees = _jsonIteration.IterateUsingStaticallyTypedObject();

        var actualCount = employees.Count;

        Assert.Equal(expectedCount, actualCount);
    }

    [Theory]
    [InlineData(5)]
    public void WhenSystemJsonIsUsed_ThenReturnListOfEmployees(int expectedCount)
    {
        var employees = _jsonIteration.IterateUsingSystemJson();

        var actualCount = employees.Count;

        Assert.Equal(expectedCount, actualCount);
    }
}