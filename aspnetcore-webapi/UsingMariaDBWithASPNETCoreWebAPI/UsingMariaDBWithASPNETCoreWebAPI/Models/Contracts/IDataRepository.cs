namespace UsingMariaDBWithASPNETCoreWebAPI.Models.Contracts;

public interface IDataRepository
{
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student?> GetAsync(int id);
    Task AddAsync(Student entity);
    Task UpdateAsync(Student entityToUpdate, Student entity);
    Task DeleteAsync(Student entity);
}