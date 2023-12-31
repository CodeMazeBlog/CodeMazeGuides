using static UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels.Contracts.IDataRepository;
using static UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels.MappingFunctions;

namespace UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels.DataManagers
{
    public class StudentDataManager(ApplicationContext context) : IDataRepository<Student, StudentDto>
    {
        readonly ApplicationContext _studentContext = context;

        public StudentDto? GetDto(int id) => MapStudentToDto(_studentContext.Students.Find(id));

        public Student? Get(int id) => _studentContext.Students.Find(id);

        public IEnumerable<StudentDto> GetAll()
        {
            var students = _studentContext.Students.ToList();
            foreach (var student in students)
            {
                yield return MapStudentToDto(student);
            }
        }

        public void Add(StudentDto entity)
        {
            var student = new Student
            { 
                Id = entity.Id,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                Address = entity.Address,
            };

            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
        }

        public void Update(Student entityToUpdate, StudentDto entity)
        {
            entityToUpdate.FirstName = entity.FirstName;
            entityToUpdate.SecondName = entity.SecondName;
            entityToUpdate.Address = entity.Address;

            _studentContext.SaveChanges();
        }

        public void Delete(Student entity)
        {
            _studentContext.Remove(entity);
            _studentContext.SaveChanges();
        }
    }
}