using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonSerializeToDictionaryDataModel;

public sealed class NewtonsoftCustomerInvoiceConverter : JsonConverter<Dictionary<Customer, List<Invoice>>>
{
    public override void WriteJson(JsonWriter writer, Dictionary<Customer, List<Invoice>>? value,
        JsonSerializer serializer)
    {
        // There is a known issue that under standard usage makes this code unnecessary as
        // the custom converter is not called when the incoming value is null, but this
        // code is added in so that we don't have nullable warnings lower in the code,
        // and it should make this converter future proof if the issue in Newtonsoft is
        // solved later.
        // https://github.com/JamesNK/Newtonsoft.Json/issues/1639
        //
        if (value is null)
        {
            writer.WriteNull();
            return;
        }

        writer.WriteStartObject();

        foreach (var (customer, invoices) in value)
        {
            writer.WritePropertyName($"Customer-{customer.CustomerId:N}");
            writer.WriteStartObject();

            writer.WritePropertyName(nameof(customer.Client));
            writer.WriteValue(customer.Client.ToString());
            writer.WritePropertyName(nameof(customer.Address));
            writer.WriteValue(customer.Address);

            writer.WritePropertyName(nameof(customer.PhoneNumber));
            writer.WriteValue(customer.PhoneNumber);

            writer.WritePropertyName("Invoices");
            var jToken = JToken.FromObject(invoices);
            jToken.WriteTo(writer);
            writer.WriteEndObject();
        }

        writer.WriteEndObject();
    }

    public override Dictionary<Customer, List<Invoice>>? ReadJson(JsonReader reader, Type objectType,
        Dictionary<Customer, List<Invoice>>? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        // Since we are only dealing with Serializing in this article, we don't need to implement the Read method
        throw new NotImplementedException();
    }

    public override bool CanRead { get; } = false;
}