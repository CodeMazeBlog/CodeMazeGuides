using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace JoinCollectionsAggregationPipeline.Models;

public class User
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [Required]
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    [BsonElement("role")] 
    public Role Role { get; set; } = new();

    public override bool Equals(object? obj)
    {
        if (obj is not User model) return false;
        return Name == model.Name
               && Email == model.Email
               && Role.Equals(model.Role);
    }
}