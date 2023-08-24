using GettingStartedASPNETMongoDB.Models;

namespace GettingStartedASPNETMongoDB.Interfaces
{
    public interface IStudentService
    {
        Task<Student> Create(Student student);

        Task Delete(string id);

        Task<List<Student>> GetAll();

        Task<Student> GetById(string id);

        Task Update(string id, Student student);
    }
}