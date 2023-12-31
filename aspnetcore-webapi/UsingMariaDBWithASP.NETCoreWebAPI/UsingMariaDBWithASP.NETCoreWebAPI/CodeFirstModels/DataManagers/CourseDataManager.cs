using static UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels.Contracts.IDataRepository;
using static UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels.MappingFunctions;

namespace UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels.DataManagers
{
    public class CourseDataManager(ApplicationContext context) : IDataRepository<Course, CourseDto>
    {
        readonly ApplicationContext _courseContext = context;

        public CourseDto? GetDto(int id) => MapCourseToDto(_courseContext.Courses.Find(id));

        public Course? Get(int id) => _courseContext.Courses.Find(id);

        public IEnumerable<CourseDto> GetAll()
        {
            var courses = _courseContext.Courses.ToList();
            foreach (var course in courses)
            {
                yield return MapCourseToDto(course);
            }
        }

        public void Add(CourseDto entity)
        {
            var course = new Course
            {
                Id = entity.Id,
               Title = entity.Title,
               CreditUnit = entity.CreditUnit,
            };

            _courseContext.Courses.Add(course);
            _courseContext.SaveChanges();
        }

        public void Update(Course entityToUpdate, CourseDto entity)
        {
            entityToUpdate.Title = entity.Title;
            entityToUpdate.CreditUnit = entity.CreditUnit;

            _courseContext.SaveChanges();
        }

        public void Delete(Course entity)
        {
            _courseContext.Remove(entity);
            _courseContext.SaveChanges();
        }
    }
}