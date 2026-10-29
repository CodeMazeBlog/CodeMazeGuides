using System.Text.Json;

namespace JsonSerializeToDictionaryDataModel.Tests;

public class CustomerKeyConverterUnitTest
{
    private static readonly Customer Customer = new(
        "123 Nowhere Street, Fakeville, MD",
        "555-555-0001",
        new Person("John", "Smith"),
        Guid.Parse("bfafbb48-f670-4e0e-87f6-d44ac219cf7b"));

    [Fact]
    public void GivenDictionaryWithCustomerKeys_WhenSerializedWithoutConverter_ThenThrowsNotSupportedException()
    {
        var dictionary = new Dictionary<Customer, int> { { Customer, 2 } };

        Assert.Throws<NotSupportedException>(() => JsonSerializer.Serialize(dictionary));
    }

    [Fact]
    public void GivenDictionaryWithCustomerKeys_WhenSerializedWithKeyConverter_ThenKeyIsCustomerId()
    {
        var dictionary = new Dictionary<Customer, int> { { Customer, 2 } };
        var options = new JsonSerializerOptions { Converters = { new CustomerKeyConverter() } };

        var result = JsonSerializer.Serialize(dictionary, options);

        Assert.Equal("{\"Customer-bfafbb48f6704e0e87f6d44ac219cf7b\":2}", result);
    }
}
