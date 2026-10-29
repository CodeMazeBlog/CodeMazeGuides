using System.Text.Json;
using JsonSerializeToDictionary;
using JsonSerializeToDictionaryDataModel;
using Newtonsoft.Json;

// Needed due to resolve ambiguity between Newtonsoft.Json.JsonSerializer and System.Text.Json
using JsonSerializer = System.Text.Json.JsonSerializer;

var fruitInventory = new Dictionary<string, int>
{
    {"apple", 3},
    {"orange", 5},
    {"banana", 7}
};

// Using Newtonsoft.Json
Console.WriteLine("============ Newtonsoft.Json ============");
var newtonsoftJson = JsonConvert.SerializeObject(fruitInventory);
Console.WriteLine(newtonsoftJson);
Console.WriteLine();

// Using System.Text.Json
Console.WriteLine("============ System.Text.Json ============");
var systemJson = JsonSerializer.Serialize(fruitInventory);
Console.WriteLine(systemJson);
Console.WriteLine();

// Using Newtonsoft.Json
Console.WriteLine("============ Newtonsoft.Json - Indented ============");
var newtonsoftJsonReadable = JsonConvert.SerializeObject(fruitInventory, Formatting.Indented);
Console.WriteLine(newtonsoftJsonReadable);
Console.WriteLine();

// Using System.Text.Json
Console.WriteLine("============ System.Text.Json - Indented ============");
var systemJsonReadable = JsonSerializer.Serialize(fruitInventory, new JsonSerializerOptions
{
    WriteIndented = true
});
Console.WriteLine(systemJsonReadable);
Console.WriteLine();

// Serializing a Dictionary of Invoices
var invoicesByCustomer = Helper.GenerateSampleInvoices();

// Using Newtonsoft.Json
Console.WriteLine("============ Complex Dictionary: Newtonsoft.Json ============");
var newtonSoftComplex = JsonConvert.SerializeObject(invoicesByCustomer, Formatting.Indented);
Console.WriteLine(newtonSoftComplex);
Console.WriteLine();

// Using Newtonsoft.Json with custom converter
Console.WriteLine("============ Complex Dictionary: Newtonsoft.Json w/ Custom Converter ============");
var newtonSoftCustomConverter =
    JsonConvert.SerializeObject(invoicesByCustomer, Formatting.Indented, new NewtonsoftCustomerInvoiceConverter());
Console.WriteLine(newtonSoftCustomConverter);
Console.WriteLine();

// Using System.Text.Json
Console.WriteLine("============ Complex Dictionary: System.Text.Json ============");
var systemJsonComplex = JsonSerializer.Serialize(invoicesByCustomer, new JsonSerializerOptions
{
    Converters = {new SystemJsonCustomerInvoiceConverter()},
    WriteIndented = true
});
Console.WriteLine(systemJsonComplex);
Console.WriteLine();

// Using System.Text.Json with a converter for the key type only
Console.WriteLine("============ Complex Dictionary: System.Text.Json w/ Key Converter ============");
var systemJsonKeyConverter = JsonSerializer.Serialize(invoicesByCustomer, new JsonSerializerOptions
{
    Converters = { new CustomerKeyConverter() },
    WriteIndented = true
});
Console.WriteLine(systemJsonKeyConverter);
Console.WriteLine();

// Using System.Text.Json after projecting the keys to Guid
Console.WriteLine("============ Complex Dictionary: System.Text.Json w/ Guid Keys ============");
var invoicesByCustomerId = invoicesByCustomer.ToDictionary(pair => pair.Key.CustomerId, pair => pair.Value);
var systemJsonGuidKeys = JsonSerializer.Serialize(invoicesByCustomerId, new JsonSerializerOptions
{
    WriteIndented = true
});
Console.WriteLine(systemJsonGuidKeys);
Console.WriteLine();

// Using System.Text.Json with a naming policy for the keys
Console.WriteLine("============ System.Text.Json - camelCase Keys ============");
var stockByProduct = new Dictionary<string, int>
{
    {"AppleCount", 3},
    {"OrangeCount", 5}
};
var systemJsonCamelCaseKeys = JsonSerializer.Serialize(stockByProduct, new JsonSerializerOptions
{
    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
});
Console.WriteLine(systemJsonCamelCaseKeys);
Console.WriteLine();