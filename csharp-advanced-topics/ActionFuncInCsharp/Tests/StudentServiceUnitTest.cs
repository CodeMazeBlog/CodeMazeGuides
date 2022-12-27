using ActionFuncInCsharp;
using Xunit;

namespace Tests
{
    public class StudentServiceUnitTest
    {
        readonly IEnumerable<Student> _students;
        readonly IEnumerable<Course> _courses;
        readonly Action<Student> _sendNotifications;

        static bool isAdminNotified = false;
        static bool isAccountNotified = false;
        public StudentServiceUnitTest()
        {
            _students = Student.DummyStudents();
            _courses = Course.DummyeCourses();
            _sendNotifications = NotifyAdmin;
            _sendNotifications += NotifyAccount;
        }

        [Theory]
        [MemberData(nameof(StudentsMatchingFilters))]
        public void WhenFilterMatchAStudent_ThenReturnThatStudent(Func<Student, bool> filter)
        {
            var student = StudentService.GetStudent(_students, filter);

            Assert.NotNull(student);
        }

        [Theory]
        [MemberData(nameof(StudentsNonMatchingFilters))]
        public void WhenFilterMatchNoStudent_ThenReturnDefault(Func<Student, bool> filter)
        {
            var student = StudentService.GetStudent(_students, filter);

            Assert.Null(student);
        }

        [Theory, MemberData(nameof(StudentCoursesMatchingFilters))]
        public void WhenStudentGetsEnrolled_ThenStudentGetsAssignedNewCourse((Func<Student, bool>, Func<IEnumerable<Course>, Course> ) studentCourseFilters)
        {
            var student = StudentService.GetStudent(_students, studentCourseFilters.Item1);
            var course = studentCourseFilters.Item2(_courses);

            StudentService.EnrollStudentToCourse(student, course, _sendNotifications);

            Assert.Equal(student.Courses.Last(), course);
        }

        [Theory, MemberData(nameof(StudentCoursesMatchingFilters))]
        public void WhenStudentGetsEnrolled_ThenNotifyDepartments((Func<Student, bool>, Func<IEnumerable<Course>, Course>) studentCourseFilters)
        {
            isAdminNotified = false;
            isAccountNotified = false;

            var student = StudentService.GetStudent(_students, studentCourseFilters.Item1);
            var course = studentCourseFilters.Item2(_courses);

            StudentService.EnrollStudentToCourse(student, course, _sendNotifications);

            Assert.True(isAdminNotified);

            Assert.True(isAccountNotified);
        }

        public static IEnumerable<object[]> StudentsMatchingFilters =>
        new List<object[]>
        {
             new object[] { StudentWithId1 },
             new object[] { StudentWithNameLara },
        };
        
        public static IEnumerable<object[]> StudentsNonMatchingFilters =>
        new List<object[]>
        {
           new object[] { StudentWithIdMax },
           new object[] { StudentWithNameAbc },
        };
        
        public static IEnumerable<object[]> StudentCoursesMatchingFilters =>
        new List<object[]>
        {
            new object[] { (StudentWithId1, CourseWithId1) },
            new object[] { (StudentWithNameLara, CourseWithNameDocker) },
        };
        
        private static void NotifyAdmin(Student student) => isAdminNotified = true;

        private static void NotifyAccount(Student student) => isAccountNotified = true;
        
        private static readonly Func<Student, bool> StudentWithId1 = (s) => s.Id == 1;

        private static readonly Func<Student, bool> StudentWithNameLara = (s) => s.Name.Equals("Lara", StringComparison.InvariantCulture);
        
        private static readonly Func<Student, bool> StudentWithIdMax = (s) => s.Id == int.MaxValue;

        private static readonly Func<Student, bool> StudentWithNameAbc = (s) => s.Name.Equals("Abc", StringComparison.InvariantCulture);
        
        private static readonly Func<IEnumerable<Course>, Course> CourseWithId1 = (c) => c.First(x => x.Id == 1);

        private static readonly Func<IEnumerable<Course>, Course> CourseWithNameDocker = (c) => c.First(x => x.Name.Equals("docker", StringComparison.InvariantCultureIgnoreCase));

    }
}