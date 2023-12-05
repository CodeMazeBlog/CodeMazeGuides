using HowToQueryMongoDB.Interfaces;
using HowToQueryMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HowToQueryMongoDB.Services;

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
        //student.Id = ObjectId.GenerateNewId().ToString();

        await _studentCollection.InsertOneAsync(student, new InsertOneOptions() { BypassDocumentValidation = true });

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

    //Querying MongoDb
    public async Task<Student> GetByIdUsingBuilder(string id)
    {
        var queryFilter = Builders<Student>.Filter.Eq(s => s.Id, id);

        return await _studentCollection.Find(queryFilter).FirstOrDefaultAsync();
    }

    public IEnumerable<Student> GetRangeOfStudentsUsingAnd(string minimumId, string maximumId)
    {
        var andFilter = Builders<Student>.Filter
            .And(
            Builders<Student>.Filter.Gt("_id", ObjectId.Parse(minimumId)),
            Builders<Student>.Filter.Lte("_id", ObjectId.Parse(maximumId)));

        return _studentCollection.Find(andFilter).ToEnumerable();
    }

    public IEnumerable<Student> GetRangeOfStudentsUsingOr(string minimumId, string maximumId)
    {
        var orFilter = Builders<Student>.Filter
            .Or(
            Builders<Student>.Filter.Gt("_id", ObjectId.Parse(minimumId)),
            Builders<Student>.Filter.Lt("_id", ObjectId.Parse(maximumId)));

        return _studentCollection.Find(orFilter).ToEnumerable();
    }

    public IEnumerable<Student> GetAllStudentsInTheList(string ids)
    {
        var objectIds = ids.Split(',').Select(x => new ObjectId(x.Trim()));

        var filter = Builders<Student>.Filter.In("Id", objectIds);

        return _studentCollection.Find(filter).ToEnumerable();
    }
}