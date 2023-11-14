using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JoinCollectionsAggregationPipeline.Entities;

public class User
{
    [BsonElement("_id")]
    [JsonPropertyName("_id")]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string Id { get; set; } = string.Empty;

    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("email")]
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [BsonElement("roleId")]
    [JsonPropertyName("roleId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string RoleId { get; set; } = string.Empty;
}