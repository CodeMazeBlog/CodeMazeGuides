using System.Text.Json.Serialization;

namespace HowToTurnCSharpObjectIntoJson.Models;

[JsonSerializable(typeof(Product))]
public partial class ProductJsonContext : JsonSerializerContext
{
}
