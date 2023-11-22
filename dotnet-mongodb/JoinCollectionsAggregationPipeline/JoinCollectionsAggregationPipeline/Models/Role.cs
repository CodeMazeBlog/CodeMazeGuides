using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace JoinCollectionsAggregationPipeline.Models;

public class Role
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [Required]
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (obj is not Role role) return false;
        return Name == role.Name;
    }
}