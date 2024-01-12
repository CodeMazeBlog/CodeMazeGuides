using UsingMariaDBWithASPNETCoreWebAPI.Models.Contracts;

namespace UsingMariaDBWithASPNETCoreWebAPI.Models.DataManagers
{
    public class StudentDataManager(ApplicationContext context) : IDataRepository
    {
        readonly ApplicationContext _studentContext = context;

        public void Add(Student entity)
        {
            _studentContext.Students.Add(entity);
            _studentContext.SaveChanges();
        }

        public Student? Get(int id) => _studentContext.Students.Find(id);

        public void Update(Student entityToUpdate, Student entity)
        {
            entityToUpdate.FirstName = entity.FirstName;
            entityToUpdate.LastName = entity.LastName;
            entityToUpdate.Address = entity.Address;

            _studentContext.SaveChanges();
        }

        public void Delete(Student entity)
        {
            _studentContext.Remove(entity);
            _studentContext.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentContext.Students.ToList();
        }
    }
}
