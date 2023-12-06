using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace JoinCollectionsAggregationPipeline.Models;

public class Student { 

    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string Id { get; set; } = string.Empty; 

    [Required]
    [BsonElement("FirstName")] 
    public string FirstName { get; set; } = string.Empty; 

    [Required]
    [EmailAddress]
    [BsonElement("LastName")] 
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [BsonElement("Major")]
    public string Major { get; set; } = string.Empty;

    [BsonElement("StudentCourses")] 
    public List<Course> StudentCourses { get; set; } = new(); 

    public override bool Equals(object? obj) 
    { 
        if (obj is not Student student) return false; 
        return FirstName == student.FirstName && 
            LastName == student.LastName 
            && StudentCourses.All(course => course
            .Equals(student.StudentCourses.ElementAt(StudentCourses.IndexOf(course)))); 
    } 
}