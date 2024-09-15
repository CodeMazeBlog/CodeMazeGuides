using HowToQueryMongoDB.Models;

namespace HowToQueryMongoDB.Interfaces;

public interface ICourseService
{
    Task<Course?> Create(Course course);

    Task<Course?> GetById(string id);
}