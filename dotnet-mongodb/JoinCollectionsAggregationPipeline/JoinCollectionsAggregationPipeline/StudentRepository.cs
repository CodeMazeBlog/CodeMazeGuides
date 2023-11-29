using MongoDB.Bson;
using MongoDB.Driver;
using JoinCollectionsAggregationPipeline.Models;

namespace JoinCollectionsAggregationPipeline;

public class StudentRepository
{
    private readonly IMongoCollection<Student> _studentCollection;

    public StudentRepository()
    {
        var client = new MongoClient(DatabaseConfiguration.ConnectionString);
        var database = client.GetDatabase(DatabaseConfiguration.DatabaseName);
        _studentCollection = database.GetCollection<Student>("Students");
    }

    public async Task<List<Student>> GetAllUsers()
    {
        //Empty Pipeline
        var studentAggregationPipeline = _studentCollection.Aggregate();

        //Lookup
        var studentsJoinedWithCoursesPipeline = studentAggregationPipeline.Lookup("Courses", "Courses", "_id", "StudentCourses");

        //Project
        var projection = Builders<BsonDocument>.Projection
            .Exclude("Courses");

        var studentsWithoutCourseIdsPipeline = studentsJoinedWithCoursesPipeline.Project(projection);

        var students = await studentsWithoutCourseIdsPipeline.As<Student>().ToListAsync();

        return students;
    }
}