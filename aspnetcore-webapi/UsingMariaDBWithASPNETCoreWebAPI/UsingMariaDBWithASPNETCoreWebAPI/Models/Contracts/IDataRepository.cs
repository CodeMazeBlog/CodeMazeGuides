namespace UsingMariaDBWithASPNETCoreWebAPI.Models.Contracts
{
    public interface IDataRepository
    {
        IEnumerable<Student> GetAll();
        Student? Get(int id);
        void Add(Student entity);
        void Update(Student entityToUpdate, Student entity);
        void Delete(Student entity);
    }
}
