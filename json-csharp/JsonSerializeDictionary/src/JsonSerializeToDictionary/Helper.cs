using JsonSerializeToDictionaryDataModel;

namespace JsonSerializeToDictionary;

internal static class Helper
{
    public static Dictionary<Customer, List<Invoice>> GenerateSampleInvoices()
    {
        var customers = new[]
        {
            new Customer(
                "123 Nowhere Street, Fakeville, MD",
                "555-555-0001",
                new Person("John", "Smith"),
                Guid.NewGuid()
            ),
            new Customer(
                "456 Somewhere Street, NotSoFakeville, DE",
                "555-555-0002",
                new Person("Jane", "Doe"),
                Guid.NewGuid()
            )
        };

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
            {customers[0], invoices.Take(2).ToList()},
            {customers[1], invoices.Skip(2).Take(2).ToList()}
        };

        return dictionary;
    }
}