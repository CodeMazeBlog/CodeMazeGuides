using GettingStartedASPNETMongoDB.Interfaces;
using GettingStartedASPNETMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GettingStartedASPNETMongoDB.Services;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<Student> _studentCollection;

    public StudentService(IOptions<SchoolDatabaseSettings> schoolDatabaseSettings, IMongoClient client)
    {
        var database = client.GetDatabase(schoolDatabaseSettings.Value.DatabaseName);

        _studentCollection = database.GetCollection<Student>(schoolDatabaseSettings.Value.StudentsCollectionName);
    }

    public async Task<List<Student>> GetAll()
    {
        return await _studentCollection.Find(s => true).ToListAsync();
    }

    public async Task<Student?> GetById(string id)
    {
        return await _studentCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Student?> Create(Student student)
    {
        student.Id = ObjectId.GenerateNewId().ToString();

        await _studentCollection.InsertOneAsync(student);

        return student;
    }

    public async Task<ReplaceOneResult> Update(string id, Student student)
    {
        return await _studentCollection.ReplaceOneAsync(s => s.Id == id, student);
    }

    public async Task<DeleteResult> Delete(string id)
    {
        return await _studentCollection.DeleteOneAsync(s => s.Id == id);
    }
}