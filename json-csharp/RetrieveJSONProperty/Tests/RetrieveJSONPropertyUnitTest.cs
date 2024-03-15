namespace Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void GivenObjectWithJsonPropertyAttribute_WhenRetrievalUsingReflection_ThenPrintJsonPropertyNames()
    {
        // Arrange
        var sales = new Sales
        {
            YearlySales = "1000",
            DailySales = "50"
        };

        // Act
        var result = JsonHelper.RetrievalUsingReflection(sales);

        // Assert
        CollectionAssert.AreEquivalent(new[] { "Slx_PER_Year", "Slx_PER_DAY" }, result);
    }

    [Test]
    public void GivenSalesObject_WhenRetrievingKeyValuesUsingSerialization_ThenReturnsCorrectKeyValuePairs()
    {
        // Arrange
        var sales = new Sales
        {
            YearlySales = "1000",
            DailySales = "50"
        };

        // Act
        var result = JsonHelper.RetrievalUsingSerialization(sales);

        // Assert
        CollectionAssert.AreEqual(new[] { "Slx_PER_Year", "Slx_PER_DAY" }, result);
    }

    [Test]
    public void Given_ObjectWithJsonPropertyAttributes_WhenGetJsonPropertyNames_ThenReturnPropertyNames()
    {
        // Arrange
        var testObject = new TestObjectWithAttributes();

        // Act
        string[] result = JsonTextImplementation.GetJsonPropertyNames(testObject);

        // Assert
        string[] expected = { "FirstName", "LastName", "Age" };
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GivenValidProductObject_WhenGettingJsonPropertyForProductName_ThenReturnCorrectProperty()
    {
        // Arrange
        var sales = new Sales
        {
            YearlySales = "1000",
            DailySales = "50"
        };

        // Act
        var property = ResolverHelper.GetJsonProperty(sales, "Slx_per_day");

        // Assert
        Assert.IsNotNull(property);
        Assert.That(property.PropertyName, Is.EqualTo("Slx_PER_DAY"));
        Assert.That(property.PropertyType, Is.EqualTo(typeof(string)));

    }

    private class TestObjectWithAttributes
    {
        [JsonPropertyName("FirstName")]
        public string? Name { get; set; }

        [JsonPropertyName("LastName")]
        public string? Surname { get; set; }

        public int Age { get; set; }
    }
}
