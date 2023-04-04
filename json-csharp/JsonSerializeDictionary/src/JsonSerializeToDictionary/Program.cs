using System.Text.Json;
using JsonSerializeToDictionaryDataModel;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

// Needed due to resolve ambiguity between Newtonsoft.Json.JsonSerializer and System.Text.Json

var fruitInventory = new Dictionary<string, int>
{
    {"apple", 3},
    {"orange", 5},
    {"banana", 7}
};

// Using Newtonsoft.Json
Console.WriteLine("============ Newtonsoft.Json ============");
var newtonsoftJson = JsonConvert.SerializeObject(fruitInventory);
Console.WriteLine("Newtonsoft.Json output:\n" + newtonsoftJson);
Console.WriteLine();

// Using System.Text.Json
Console.WriteLine("============ System.Text.Json ============");
var systemJson = JsonSerializer.Serialize(fruitInventory);
Console.WriteLine("System.Text.Json output:\n" + systemJson);
Console.WriteLine();

// Using Newtonsoft.Json
Console.WriteLine("============ Newtonsoft.Json - Indented ============");
var newtonsoftJsonReadable = JsonConvert.SerializeObject(fruitInventory, Formatting.Indented);
Console.WriteLine("Newtonsoft.Json output:\n" + newtonsoftJsonReadable);
Console.WriteLine();

// Using System.Text.Json
Console.WriteLine("============ System.Text.Json - Indented ============");
var systemJsonReadable = JsonSerializer.Serialize(fruitInventory, new JsonSerializerOptions
{
    WriteIndented = true
});
Console.WriteLine("System.Text.Json output:\n" + systemJsonReadable);
Console.WriteLine();

// Serializing a Dictionary of Invoices
var invoicesByCustomer = GenerateSampleInvoices();

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

Dictionary<Customer, List<Invoice>> GenerateSampleInvoices()
{
    var customer1 = new Customer(
        "123 Nowhere Street, Fakeville, MD",
        "555-555-0001",
        new Person("John", "Smith"),
        Guid.NewGuid()
    );
    var customer2 = new Customer(
        "456 Somewhere Street, NotSoFakeville, DE",
        "555-555-0002",
        new Person("Jane", "Doe"),
        Guid.NewGuid()
    );

    var products = new List<Product>
    {
        new("Widget", 1.27m, Guid.NewGuid()),
        new("Thing", 35.72m, Guid.NewGuid()),
        new("Gadget", 42.42m, Guid.NewGuid()),
        new("WhatzIt", 0.97m, Guid.NewGuid())
    };

    var invoices = new List<Invoice>
    {
        new(
            DateTime.Now.AddDays(-14),
            Guid.NewGuid(),
            new List<InvoiceLineItem>
            {
                new(products[0], 10),
                new(products[1], 10)
            }
        ),
        new(
            DateTime.Now.AddDays(-7),
            Guid.NewGuid(),
            new List<InvoiceLineItem>
            {
                new(products[2], 10),
                new(products[3], 10)
            }
        ),
        new(
            DateTime.Now.AddDays(-10),
            Guid.NewGuid(),
            new List<InvoiceLineItem>
            {
                new(products[0], 20),
                new(products[2], 20)
            }
        ),
        new(
            DateTime.Now.AddDays(-5),
            Guid.NewGuid(),
            new List<InvoiceLineItem>
            {
                new(products[1], 20),
                new(products[3], 20)
            }
        )
    };

    var dictionary = new Dictionary<Customer, List<Invoice>>
    {
        {customer1, invoices.Take(2).ToList()},
        {customer2, invoices.Skip(2).Take(2).ToList()}
    };
    return dictionary;
}