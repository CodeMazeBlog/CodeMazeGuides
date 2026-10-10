using System.Text.Json.Serialization;

namespace JsonObjectsWithHttpClient;

[JsonSerializable(typeof(PetDto))]
public partial class PetContext : JsonSerializerContext
{
}