using Bogus;
using NJsonSchema;

namespace JsonSerializeToDictionaryDataModel.Tests;

public class DictionaryOfCustomersAndInvoicesTestFixture
{
    private const int CustomerCount = 10;
    private const int ProductCount = 100;
    private const int MaxLineItemCount = 35;
    private const int MaxInvoiceCount = 50;
    private const int MaxYearsBack = 3;
    private static readonly DateTime Today = new(2023, 4, 1);

    static DictionaryOfCustomersAndInvoicesTestFixture()
    {
        Randomizer.Seed = new Random(42);
    }

    public DictionaryOfCustomersAndInvoicesTestFixture()
    {
        TestInvoiceData = GenerateSampleInvoices();
        Schema = JsonSchema.FromFileAsync(@"./Resources/CustomSerializerExpectedSchema.json").Result;
    }

    public Dictionary<Customer, List<Invoice>> TestInvoiceData { get; }
    public JsonSchema Schema { get; }
    public Dictionary<Customer, List<Invoice>> EmptyDictionary { get; } = new();

    private static Dictionary<Customer, List<Invoice>> GenerateSampleInvoices()
    {
        var dictionary = new Dictionary<Customer, List<Invoice>>();
        var customerFaker = new Faker<Customer>()
            .CustomInstantiator(f =>
                new Customer(
                    f.Address.FullAddress(),
                    f.Phone.PhoneNumber("###-###-####"),
                    new Person(f.Person.FirstName, f.Person.LastName),
                    Guid.NewGuid()
                )
            );

        var productFaker = new Faker<Product>()
            .CustomInstantiator(f =>
                new Product(f.Commerce.ProductName(),
                    decimal.Parse(f.Commerce.Price()),
                    Guid.NewGuid()
                )
            );

        var products = productFaker.Generate(ProductCount);

        var invoiceItemFaker = new Faker<InvoiceLineItem>()
            .CustomInstantiator(f =>
                new InvoiceLineItem(f.Random.CollectionItem(products),
                    f.Random.Number(1, 1000)
                )
            );

        var invoiceFaker = new Faker<Invoice>()
            .CustomInstantiator(f =>
                new Invoice(f.Date.Past(MaxYearsBack, Today),
                    Guid.NewGuid(),
                    invoiceItemFaker.Generate(f.Random.Number(1, MaxLineItemCount))
                )
            );

        var customers = customerFaker.Generate(CustomerCount);
        foreach (var customer in customers)
        {
            var list = invoiceFaker.Generate(Randomizer.Seed.Next(1, MaxInvoiceCount));
            dictionary.Add(customer, list);
        }

        return dictionary;
    }
}

[CollectionDefinition("Dictionary Collection")]
public class
    DictionaryOfCustomersAndInvoicesCollection : ICollectionFixture<DictionaryOfCustomersAndInvoicesTestFixture>
{
}