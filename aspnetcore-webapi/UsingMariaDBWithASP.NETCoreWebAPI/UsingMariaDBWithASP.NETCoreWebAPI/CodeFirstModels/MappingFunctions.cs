using Mapster;

namespace UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels
{
    public static class MappingFunctions
    {
        public static StudentDto MapStudentToDto(Student? student)
        {
            return student.Adapt<StudentDto>();
        }

        public static CourseDto MapCourseToDto(Course? course)
        {
            return course.Adapt<CourseDto>();
        }
    }
}