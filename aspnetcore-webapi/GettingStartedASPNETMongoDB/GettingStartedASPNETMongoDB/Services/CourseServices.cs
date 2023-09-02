using Microsoft.Extensions.Options;
using MongoDB.Driver;
using GettingStartedASPNETMongoDB.Interfaces;
using GettingStartedASPNETMongoDB.Models;

namespace GettingStartedASPNETMongoDB.Services;


public class CourseService : ICourseService
{
    private readonly IMongoCollection<Course> _courseCollection;

    public CourseService(IOptions<SchoolDatabaseSettings> schoolDatabaseSettings)
    {
        var client = new MongoClient(schoolDatabaseSettings.Value.ConnectionString);

        var database = client.GetDatabase(schoolDatabaseSettings.Value.DatabaseName);

        _courseCollection = database.GetCollection<Course>(schoolDatabaseSettings.Value.CoursesCollectionName);
    }

    public async Task<Course> GetById(string id)
    {
        return await _courseCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Course> Create(Course course)
    {
        await _courseCollection.InsertOneAsync(course);

        return course;
    }
}