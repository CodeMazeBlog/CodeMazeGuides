using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerializeToDictionaryDataModel;

public sealed class SystemJsonCustomerInvoiceConverter : JsonConverter<Dictionary<Customer, List<Invoice>>>
{
    public override Dictionary<Customer, List<Invoice>> Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        // Since we are only dealing with Serializing in this article, we don't need to implement the Read method
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<Customer, List<Invoice>> value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        foreach (var (customer, invoices) in value)
        {
            writer.WritePropertyName($"Customer-{customer.CustomerId:N}");
            writer.WriteStartObject();

            writer.WritePropertyName(nameof(customer.Client));
            writer.WriteStringValue(customer.Client.ToString());
            writer.WritePropertyName(nameof(customer.Address));
            writer.WriteStringValue(customer.Address);

            writer.WritePropertyName(nameof(customer.PhoneNumber));
            writer.WriteStringValue(customer.PhoneNumber);

            writer.WritePropertyName("Invoices");
            writer.WriteStartArray();

            foreach (var invoice in invoices)
            {
                writer.WriteStartObject();

                writer.WritePropertyName(nameof(invoice.InvoiceDate));
                writer.WriteStringValue(invoice.InvoiceDate);

                writer.WritePropertyName(nameof(invoice.InvoiceId));
                writer.WriteStringValue(invoice.InvoiceId);

                writer.WritePropertyName(nameof(invoice.Items));
                writer.WriteStartArray();

                foreach (var item in invoice.Items)
                {
                    writer.WriteStartObject();

                    writer.WritePropertyName("Item");
                    writer.WriteStartObject();

                    writer.WritePropertyName(nameof(item.Item.Name));
                    writer.WriteStringValue(item.Item.Name);
                    writer.WritePropertyName(nameof(item.Item.CostPerItem));
                    writer.WriteNumberValue(item.Item.CostPerItem);
                    writer.WritePropertyName(nameof(item.Item.ProductId));
                    writer.WriteStringValue(item.Item.ProductId);
                    writer.WriteEndObject();

                    writer.WritePropertyName(nameof(item.Quantity));
                    writer.WriteNumberValue(item.Quantity);

                    writer.WriteEndObject();
                }

                writer.WriteEndArray();

                writer.WriteEndObject();
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        writer.WriteEndObject();
    }
}