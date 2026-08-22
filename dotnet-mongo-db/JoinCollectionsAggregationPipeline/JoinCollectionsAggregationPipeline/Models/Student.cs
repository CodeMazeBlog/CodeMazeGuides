using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JoinCollectionsAggregationPipeline.Models;

public class Student
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("FirstName")]
    public string FirstName { get; set; } = string.Empty;

    [BsonElement("LastName")]
    public string LastName { get; set; } = string.Empty;

    [BsonElement("Major")]
    public string Major { get; set; } = string.Empty;

    [BsonElement("StudentCourses")]
    public List<Course> StudentCourses { get; set; } = [];

    public override bool Equals(object? obj)
    {
        if (obj is not Student student) return false;
        return FirstName == student.FirstName
            && LastName == student.LastName
            && StudentCourses.SequenceEqual(student.StudentCourses);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(FirstName);
        hash.Add(LastName);

        foreach (var course in StudentCourses)
            hash.Add(course);

        return hash.ToHashCode();
    }
}
