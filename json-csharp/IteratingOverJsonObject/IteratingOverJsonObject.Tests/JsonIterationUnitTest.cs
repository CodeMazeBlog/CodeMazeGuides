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
        var jsonString = _jsonIteration.Json;
        _jsonIteration.IterateOverJsonDynamically(jsonString);

        var actualCount = _jsonIteration.ItemsCount;

        Assert.Equal(expectedCount, actualCount);
    }

    [Theory]
    [InlineData(5)]
    public void WhenJArrayIsUsed_ThenIncreaseCount(int expectedCount)
    {
        var jsonString = _jsonIteration.Json;
        _jsonIteration.IterateUsingJArray(jsonString);

        var actualCount = _jsonIteration.ItemsCount;

        Assert.Equal(expectedCount, actualCount);
    }

    [Theory]
    [InlineData(5)]
    public void WhenStaticListIsUsed_ThenReturnListOfEmployees(int expectedCount)
    {
        var jsonString = _jsonIteration.Json;
        var employees = _jsonIteration.IterateUsingStaticObject(jsonString);

        var actualCount = employees.Count;

        Assert.Equal(expectedCount, actualCount);
    }

    [Theory]
    [InlineData(5)]
    public void WhenSystemJsonIsUsed_ThenReturnListOfEmployees(int expectedCount)
    {
        var jsonString = _jsonIteration.Json;
        var employees = _jsonIteration.IterateUsingSystemJson(jsonString);

        var actualCount = employees.Count;

        Assert.Equal(expectedCount, actualCount);
    }
}