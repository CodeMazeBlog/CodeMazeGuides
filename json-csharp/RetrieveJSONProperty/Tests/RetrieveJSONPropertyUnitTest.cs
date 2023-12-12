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
        CollectionAssert.AreEquivalent(new[] { "Yearly", "Daily" }, result);
    }

    [Test]
    public void GivenSalesObject_WhenRetrievingKeyValuesUsingSerialization_ThenReturnsCorrectKeyValuePairs()
    {
        // Arrange
        var product = new Product
        {
            ProductId = "123",
            ProductName = "SampleProduct"
        };

        // Act
        var result = JsonHelper.RetrievalUsingSerialization(product);

        // Assert
        CollectionAssert.AreEqual(new[] { "productId", "productName" }, result);
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
        var product = new Product { ProductId = "P123", ProductName = "TestProduct" };

        // Act
        var property = ResolverHelper.GetJsonProperty(product, "ProductName");

        // Assert
        Assert.IsNotNull(property);
        Assert.That(property.PropertyName, Is.EqualTo("productName"));
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

    private class Sales
    {
        [JsonProperty("Yearly")]
        public string? YearlySales { get; set; }

        [JsonProperty("Daily")]
        public string? DailySales { get; set; }
    }
}
