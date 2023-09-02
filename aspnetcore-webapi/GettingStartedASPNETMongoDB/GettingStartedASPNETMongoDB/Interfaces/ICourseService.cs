using GettingStartedASPNETMongoDB.Models;

namespace GettingStartedASPNETMongoDB.Interfaces;

public interface ICourseService
{
    Task<Course> Create(Course course);

    Task<Course> GetById(string id);
}