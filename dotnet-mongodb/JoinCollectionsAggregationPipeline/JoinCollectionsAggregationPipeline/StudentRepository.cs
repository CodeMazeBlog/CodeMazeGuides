using MongoDB.Bson;
using MongoDB.Driver;
using JoinCollectionsAggregationPipeline.Models;

namespace JoinCollectionsAggregationPipeline;

public class StudentRepository
{
    private readonly IMongoCollection<Student> _studentCollection;

    public StudentRepository(MongoClient client)
    {;
        var database = client.GetDatabase(DatabaseConfiguration.DatabaseName);
        _studentCollection = database.GetCollection<Student>("Students");
    }

    public async Task<List<Student>> GetAllUsers()
    {
        //Empty Pipeline
        var studentAggregationPipeline = _studentCollection.Aggregate();

        //Lookup
        var studentsJoinedWithCoursesPipeline = studentAggregationPipeline
            .Lookup<Student, Student>("Courses", "Courses", "_id", "StudentCourses");

        //Project
        var projection = Builders<Student>.Projection
            .Exclude("Courses");

        var studentsWithoutCourseIdsPipeline = studentsJoinedWithCoursesPipeline.Project<Student>(projection);

        var students = await studentsWithoutCourseIdsPipeline.ToListAsync();

        return students;
    }
}