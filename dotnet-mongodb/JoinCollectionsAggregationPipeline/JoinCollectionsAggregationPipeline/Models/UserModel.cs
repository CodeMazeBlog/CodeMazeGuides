using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace JoinCollectionsAggregationPipeline.Models;

public class UserModel
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [Required]
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [EmailAddress]
    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    [BsonElement("role")] 
    public RoleModel Role { get; set; } = new();

    public override bool Equals(object? obj)
    {
        if (obj is not UserModel model) return false;
        return Id == model.Id
               && Name == model.Name
               && Email == model.Email
               && Role.Id == model.Role.Id
               && Role.Name == model.Role.Name;
    }
}