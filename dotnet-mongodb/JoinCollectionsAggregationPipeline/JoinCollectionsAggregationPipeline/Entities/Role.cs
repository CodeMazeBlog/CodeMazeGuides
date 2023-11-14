using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JoinCollectionsAggregationPipeline.Entities;

public class Role
{
    [BsonElement("_id")]
    [JsonPropertyName("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("normalizedName")]
    [JsonPropertyName("normalizedName")]
    public string NormalizedName => Name.ToUpper();
}