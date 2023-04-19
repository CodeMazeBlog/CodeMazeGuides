using System.Text.Json;

namespace JsonSerializeToDictionaryDataModel.Tests;

[Collection("Dictionary Collection")]
public class SystemJsonCustomerInvoiceConverterUnitTest
{
    private readonly DictionaryOfCustomersAndInvoicesTestFixture _fixture;

    public SystemJsonCustomerInvoiceConverterUnitTest(DictionaryOfCustomersAndInvoicesTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GivenDictionaryOfCustomersAndInvoices_WhenSerializes_ThenProducedJsonMatchesExpectedSchema()
    {
        // Serialize the object
        var result = JsonSerializer.Serialize(_fixture.TestInvoiceData, new JsonSerializerOptions
        {
            Converters = {new SystemJsonCustomerInvoiceConverter()}
        });

        // Validate it against our expected schema
        var errors = _fixture.Schema.Validate(result);

        Assert.Empty(errors);
    }

    [Fact]
    public void GivenEmptyDictionary_WhenSerializes_ThenProducedJsonMatchesExpectedSchema()
    {
        // Serialize the object
        var result = JsonSerializer.Serialize(_fixture.EmptyDictionary, new JsonSerializerOptions
        {
            Converters = {new SystemJsonCustomerInvoiceConverter()}
        });

        // Validate it against our expected schema
        var errors = _fixture.Schema.Validate(result);

        Assert.Empty(errors);
    }

    [Fact]
    public void GivenEmptyDictionary_WhenSerializes_ThenJsonResultIsEmpty()
    {
        // Serialize the object
        var result = JsonSerializer.Serialize(_fixture.EmptyDictionary, new JsonSerializerOptions
        {
            Converters = {new SystemJsonCustomerInvoiceConverter()}
        });


        Assert.Equal("{}", result);
    }
}