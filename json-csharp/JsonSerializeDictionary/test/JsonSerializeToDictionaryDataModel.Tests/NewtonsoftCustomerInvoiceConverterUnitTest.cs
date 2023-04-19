using Newtonsoft.Json;

namespace JsonSerializeToDictionaryDataModel.Tests;

[Collection("Dictionary Collection")]
public class NewtonsoftCustomerInvoiceConverterUnitTest
{
    private readonly DictionaryOfCustomersAndInvoicesTestFixture _fixture;

    public NewtonsoftCustomerInvoiceConverterUnitTest(DictionaryOfCustomersAndInvoicesTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GivenDictionaryOfCustomersAndInvoices_WhenSerializes_ThenProducedJsonMatchesExpectedSchema()
    {
        // Serialize the object
        var result = JsonConvert.SerializeObject(_fixture.TestInvoiceData, new NewtonsoftCustomerInvoiceConverter());

        // Validate it against our expected schema
        var errors = _fixture.Schema.Validate(result);

        Assert.Empty(errors);
    }

    [Fact]
    public void GivenEmptyDictionary_WhenSerializes_ThenProducedJsonMatchesExpectedSchema()
    {
        // Serialize the object
        var result = JsonConvert.SerializeObject(_fixture.EmptyDictionary, new NewtonsoftCustomerInvoiceConverter());

        // Validate it against our expected schema
        var errors = _fixture.Schema.Validate(result);

        Assert.Empty(errors);
    }

    [Fact]
    public void GivenEmptyDictionary_WhenSerializes_ThenJsonResultIsEmpty()
    {
        // Serialize the object
        var result = JsonConvert.SerializeObject(_fixture.EmptyDictionary, new NewtonsoftCustomerInvoiceConverter());


        Assert.Equal("{}", result);
    }
}