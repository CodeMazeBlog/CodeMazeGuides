using System.Text.Json;

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
        Assert.That(result, Is.EquivalentTo(new[] { "Slx_PER_Year", "Slx_PER_DAY" }));
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
        Assert.That(result, Is.EqualTo(new[] { "Slx_PER_Year", "Slx_PER_DAY" }));
    }

    [Test]
    public void GivenObjectWithNonStringProperty_WhenRetrievingUsingSerialization_ThenReturnsAllNames()
    {
        // Arrange
        var testObject = new NewtonsoftObjectWithNumber { Name = "Widget", Quantity = 3 };

        // Act
        var result = JsonHelper.RetrievalUsingSerialization(testObject);

        // Assert
        Assert.That(result, Is.EqualTo(new[] { "product_name", "Quantity" }));
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
    public void GivenSalesType_WhenGetSerializedPropertyNames_ThenReturnJsonPropertyNames()
    {
        // Act
        string[] result = JsonTextImplementation.GetSerializedPropertyNames<Sales>();

        // Assert
        Assert.That(result, Is.EqualTo(new[] { "Slx_PER_Year", "Slx_PER_DAY" }));
    }

    [Test]
    public void GivenWebDefaults_WhenGetSerializedPropertyNames_ThenNamingPolicyAppliesOnlyWithoutAttribute()
    {
        // Arrange
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        // Act
        string[] result = JsonTextImplementation.GetSerializedPropertyNames<TestObjectWithAttributes>(options);

        // Assert
        Assert.That(result, Is.EqualTo(new[] { "FirstName", "LastName", "age" }));
    }

    [Test]
    public void GivenWebDefaults_WhenSerializing_ThenOutputUsesSameNamesAsGetSerializedPropertyNames()
    {
        // Arrange
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        var testObject = new TestObjectWithAttributes { Name = "Ana", Surname = "Lee", Age = 30 };

        // Act
        string json = System.Text.Json.JsonSerializer.Serialize(testObject, options);
        string[] namesInJson = JsonDocument.Parse(json).RootElement
            .EnumerateObject()
            .Select(property => property.Name)
            .ToArray();

        // Assert
        Assert.That(namesInJson,
            Is.EqualTo(JsonTextImplementation.GetSerializedPropertyNames<TestObjectWithAttributes>(options)));
    }

    [Test]
    public void GivenIgnoredProperty_WhenGetSerializedPropertyNames_ThenSkipsIt()
    {
        // Act
        string[] result = JsonTextImplementation.GetSerializedPropertyNames<ObjectWithIgnoredProperty>();

        // Assert
        Assert.That(result, Is.EqualTo(new[] { "id" }));
    }

    [Test]
    public void GivenIgnoredProperty_WhenGetJsonPropertyNames_ThenReflectionStillReturnsIt()
    {
        // Act
        string[] result = JsonTextImplementation.GetJsonPropertyNames(new ObjectWithIgnoredProperty());

        // Assert
        Assert.That(result, Is.EqualTo(new[] { "id", "Password" }));
    }

    [Test]
    public void GivenCustomer_WhenComparingReflectionWithWebDefaultsMetadata_ThenOnlyMetadataAppliesPolicyAndIgnore()
    {
        // Arrange
        var webOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        // Act
        string[] fromReflection = JsonTextImplementation.GetJsonPropertyNames(new Customer());
        string[] fromSerializer = JsonTextImplementation.GetSerializedPropertyNames<Customer>(webOptions);

        // Assert
        Assert.That(fromReflection, Is.EqualTo(new[] { "FirstName", "Password", "Age" }));
        Assert.That(fromSerializer, Is.EqualTo(new[] { "FirstName", "age" }));
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
        Assert.That(property, Is.Not.Null);
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

    private class NewtonsoftObjectWithNumber
    {
        [JsonProperty("product_name")]
        public string? Name { get; set; }

        public int Quantity { get; set; }
    }

    private class ObjectWithIgnoredProperty
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public string? Password { get; set; }
    }
}
