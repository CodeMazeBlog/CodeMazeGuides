using HowToQueryMongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HowToQueryMongoDB.Interfaces;

public interface IStudentService
{
    Task<Student?> Create(Student student);

    Task<DeleteResult> Delete(string id);

    Task<List<Student>> GetAll();

    Task<Student?> GetById(string id);

    Task<ReplaceOneResult> Update(string id, Student student);

    Task<Student> GetByIdUsingBuilder(string id);

    IEnumerable<Student> GetRangeOfStudentsUsingAnd(string minimumId, string maximumId);

    IEnumerable<Student> GetRangeOfStudentsUsingOr(string minimumId, string maximumId);

    IEnumerable<Student> GetAllStudentsInTheList(string ids);
}