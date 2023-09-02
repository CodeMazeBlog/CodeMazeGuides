using Microsoft.Extensions.Options;
using MongoDB.Driver;
using GettingStartedASPNETMongoDB.Interfaces;
using GettingStartedASPNETMongoDB.Models;

namespace GettingStartedASPNETMongoDB.Services;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<Student> _studentCollection;

    public StudentService(IOptions<SchoolDatabaseSettings> schoolDatabaseSettings)
    {
        var client = new MongoClient(schoolDatabaseSettings.Value.ConnectionString);

        var database = client.GetDatabase(schoolDatabaseSettings.Value.DatabaseName);

        _studentCollection = database.GetCollection<Student>(schoolDatabaseSettings.Value.StudentsCollectionName);
    }

    public async Task<List<Student>> GetAll()
    {
        return await _studentCollection.Find(s => true).ToListAsync();
    }

    public async Task<Student> GetById(string id)
    {
        return await _studentCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Student> Create(Student student)
    {
        await _studentCollection.InsertOneAsync(student);

        return student;
    }

    public async Task Update(string id, Student student)
    {
        await _studentCollection.ReplaceOneAsync(s => s.Id == id, student);
    }

    public async Task Delete(string id)
    {
        await _studentCollection.DeleteOneAsync(s => s.Id == id);
    }
}