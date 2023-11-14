using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace JoinCollectionsAggregationPipeline.Models;

public class RoleModel
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("normalizedName")]
    public string NormalizedName => Name.ToUpper();

    public override bool Equals(object? obj)
    {
        if (obj is not RoleModel model) return false;
        return Id == model.Id
               && Name == model.Name
               && NormalizedName == model.NormalizedName;
    }
}