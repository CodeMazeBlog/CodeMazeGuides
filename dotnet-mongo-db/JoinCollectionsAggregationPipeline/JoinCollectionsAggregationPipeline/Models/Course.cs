using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace JoinCollectionsAggregationPipeline.Models;

public class Course
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string Id { get; set; } = string.Empty; 

    [Required]
    [BsonElement("Name")] 
    public string Name { get; set; } = string.Empty;

    [Required]
    [BsonElement("Code")]
    public string Code { get; set; } = string.Empty; 

    public override bool Equals(object? obj)
    {
        if (obj is not Course course) return false; 
        return Name == course.Name
                && Code == course.Code;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Code);
    }
}