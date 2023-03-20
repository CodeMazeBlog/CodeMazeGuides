using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CustomJsonConverter.Converters;

public class SmartContactConverter : JsonConverter<Contact>
{
    public override void WriteJson(JsonWriter writer, Contact? contact, JsonSerializer serializer)
    {
        if (contact is null) return;

        JObject jo = new();
        jo[nameof(contact.Name)] = contact.Name;
        jo[nameof(contact.Department)] = contact.Department.ToString();

        if (contact.Department == Department.CustomerCare)
        {
            jo[nameof(contact.Phone)] = contact.Phone;
        }
        jo[nameof(contact.Address)] = JToken.FromObject(contact.Address, serializer);

        jo.WriteTo(writer);
    }

    public override Contact? ReadJson(JsonReader reader, Type objectType, Contact? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jo = JObject.Load(reader);

        if (jo[nameof(SuperContact.Mobile)] is not null)
        {
            var superContact = jo.ToObject<SuperContact>();
            return superContact;
        }

        if (jo[nameof(MasterContact.Email)] is not null)
        {
            var masterContact = jo.ToObject<MasterContact>();
            return masterContact;
        }           

        return jo.ToObject<Contact>();
    }

    public override bool CanWrite => true;

    public override bool CanRead => true;
}